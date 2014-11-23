using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Data;
using BullsAndCows.Models;

namespace BullsAndCows.WebApi.Controllers
{
    public class GuessController : BaseApiController
    {
        public GuessController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Guess(int id, NumberDataModel number)
        {
            var currentGame = this.data.Games.Find(id);
            var currentUserId = this.User.Identity.GetUserId();

            if (currentGame == null)
            {
                 return BadRequest("There is no game with such id!");
            }

            if (currentGame.BlueId != currentUserId && currentGame.RedId != currentUserId)
            {
                return BadRequest("You do not participate in this game!");
            }

            bool currentUserIsBlue = currentGame.BlueId == currentUserId ? true : false;

            if (currentUserIsBlue && currentGame.State != BullsAndCows.Models.GameState.BluePlayerTurn ||
                !currentUserIsBlue && currentGame.State != BullsAndCows.Models.GameState.RedPlayerTurn)
            {
                return BadRequest("It's not oyur turn!");
            }

            var guess = new Guess
            {
                DateMade = DateTime.Now,
                GameId = currentGame.Id,
                Number = number.number,
                UserId = currentUserId
            };

            if (currentUserIsBlue && number.number == currentGame.RedsNumber)
            {
                currentGame.State = BullsAndCows.Models.GameState.WonByBluePlayer;
                currentGame.Blue.Wins += 1;
                currentGame.Red.Losses += 1;

                var winNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("You beat {0} in game {1}", currentGame.Red.UserName, currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.GameWon,
                    UserId = currentUserId
                };

                var loseNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("{0} beat you in game {1}", currentGame.Blue.UserName, currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.GameLost,
                    UserId = currentGame.RedId
                };

                guess.BullsCount = 4;
                guess.CowsCount = 0;

                this.data.Guesses.Add(guess);
                this.data.Notifications.Add(winNotification);
                this.data.Notifications.Add(loseNotification);
            }

            if (currentUserIsBlue && number.number != currentGame.RedsNumber)
            {
                var yourTurnNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("It's your turn in game {1}", currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.YourTurn,
                    UserId = currentGame.RedId
                };

                //game logic .. .. 

                this.data.Guesses.Add(guess);
                this.data.Notifications.Add(yourTurnNotification);
            }

            if (!currentUserIsBlue && number.number == currentGame.BluesNumber)
            {
                currentGame.State = BullsAndCows.Models.GameState.WonByRedPlayer;
                currentGame.Red.Wins += 1;
                currentGame.Blue.Losses += 1;

                var winNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("You beat {0} in game {1}", currentGame.Blue.UserName, currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.GameWon,
                    UserId = currentGame.RedId
                };

                var loseNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("{0} beat you in game {1}", currentGame.Red.UserName, currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.GameLost,
                    UserId = currentGame.BlueId
                };

                guess.BullsCount = 4;
                guess.CowsCount = 0;

                this.data.Guesses.Add(guess);
                this.data.Notifications.Add(winNotification);
                this.data.Notifications.Add(loseNotification);
            }

            if (!currentUserIsBlue && number.number != currentGame.BluesNumber)
            {
                var yourTurnNotification = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = currentGame.Id,
                    Message = string.Format("It's your turn in game {1}", currentGame.Name),
                    State = NotificationState.Unread,
                    Type = NotificationType.YourTurn,
                    UserId = currentGame.BlueId
                };

                //game logic .. .. 

                this.data.Guesses.Add(guess);
                this.data.Notifications.Add(yourTurnNotification);
            }

            this.data.SaveChanges();

            return Ok(guess);
        }
    }
}
