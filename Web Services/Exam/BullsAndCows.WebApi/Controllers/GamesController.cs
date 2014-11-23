using BullsAndCows.Data;
using BullsAndCows.WebApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Models;

namespace BullsAndCows.WebApi.Controllers
{
    public class GamesController : BaseApiController
    {
        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAvailableGames()
        {
            return this.GetAvailableGames(0);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableGames(int page)
        {
            var availableGames = this.data.Games.All()
                .Where(g => g.State == BullsAndCows.Models.GameState.WaitingForSecondPlayer)
                .OrderBy(g => g.State)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.Red.UserName)
                .Skip(page * 10)
                .Take(10)
                .Select(GameDataModel.FromGame).ToList();

            return Ok(availableGames);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAvailableGamesLoggedUser()
        {
            return this.GetAvailableGamesLoggedUser(0);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAvailableGamesLoggedUser(int page)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var availableGames = this.data.Games.All()
                .Where(g => (g.Blue.Id == currentUserId || g.Red.Id == currentUserId) ||
                    (g.State == BullsAndCows.Models.GameState.WaitingForSecondPlayer))
                .OrderBy(g => g.State)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.Red.UserName)
                .Skip(page * 10)
                .Take(10)
                .Select(GameDataModel.FromGame).ToList();

            return Ok(availableGames);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetGamesDetails(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var currentGame = this.data.Games.Find(id);

            if (currentUserId != currentGame.Red.Id && currentUserId != currentGame.Blue.Id)
            {
                return BadRequest("You are not part of this game!");
            }

            var currentGameDetails = GameDetailsDataModel.GetGameDetailsDataModel(currentGame, currentUserId);

            return Ok(currentGameDetails);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateGame(CreateGameDataModel gameRequest)
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (gameRequest == null || !ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingGameWithName = this.data.Games.All().FirstOrDefault(g => g.Name == gameRequest.name);
            if (existingGameWithName != null)
            {
                return BadRequest("There is already a game with this name!");
            }

            var newGame = new Game
            {
                Name = gameRequest.name,
                RedId = currentUserId,
                DateCreated = DateTime.Now,
                RedsNumber = gameRequest.number,
                State = GameState.WaitingForSecondPlayer
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            var createdGame = this.data.Games.All().Where(g => g.Name == gameRequest.name).Select(GameDataModel.FromGame).FirstOrDefault();

            var location = "api/games/" + createdGame.Id;

            return Created(location, createdGame);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult JoinGame(int id, NumberDataModel number)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUserName = this.User.Identity.GetUserName();

            if (!ModelState.IsValid)
            {
                return BadRequest("Number must be greater than 999 and smaller than 10000!");
            }

            var existingGame = this.data.Games.All()
                .Where(g => g.State == GameState.WaitingForSecondPlayer && g.RedId != currentUserId)
                .FirstOrDefault();

            if (existingGame == null)
            {
                return NotFound();
            }

            existingGame.BlueId = currentUserId;
            existingGame.BluesNumber = number.number;
            existingGame.State = GameState.BluePlayerTurn;

            //The red player (the creator) receives a message that a blue player has joined his game.
            var joinNotification = new Notification
            {
                GameId = existingGame.Id,
                DateCreated = DateTime.Now,
                Message = string.Format("{0} joined your game {1}",currentUserName, existingGame.Name),
                State = NotificationState.Unread,
                Type = NotificationType.GameJoined,
                UserId = existingGame.RedId
            };

            //The selected player in turn receives a notification that their turn has come up
            var yourTurnNotification = new Notification
            {
                GameId = existingGame.Id,
                DateCreated = DateTime.Now,
                Message = string.Format("It's your turn in game {1}", existingGame.Name),
                State = NotificationState.Unread,
                Type = NotificationType.YourTurn,
                UserId = existingGame.BlueId
            };

            this.data.SaveChanges();

            var responseText = string.Format("You joined the game {0}", existingGame.Name);
            var response = new { result = responseText };

            return Ok(response);
        }
    }
}
