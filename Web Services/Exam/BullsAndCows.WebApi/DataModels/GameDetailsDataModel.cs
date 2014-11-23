using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class GameDetailsDataModel
    {
        public GameDetailsDataModel()
        {
            this.YourGuesses = new HashSet<GuessDataModel>();
            this.OpponentGuesses = new HashSet<GuessDataModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public int YourNumber { get; set; }

        public ICollection<GuessDataModel> YourGuesses { get; set; }

        public ICollection<GuessDataModel> OpponentGuesses { get; set; }

        public string YourColour { get; set; }

        public string GameState { get; set; }

        public static GameDetailsDataModel GetGameDetailsDataModel(Game game, string userId)
        {
            bool userIsBlue = game.BlueId == userId ? true : false;

            var gameDetailsModel = new GameDetailsDataModel
            {
                Id = game.Id,
                Name = game.Name,
                Red = game.Red.UserName,
                Blue = game.Blue != null ? game.Blue.UserName : "No blue player yet",
            };

            gameDetailsModel.YourNumber = userIsBlue ? game.BluesNumber : game.RedsNumber;

            gameDetailsModel.YourGuesses = game.Guesses.AsQueryable()
                .Where(g => g.UserId == userId)
                .Select(GuessDataModel.FromGuess).ToList();

            gameDetailsModel.OpponentGuesses = game.Guesses.AsQueryable()
                .Where(g => g.UserId != userId)
                .Select(GuessDataModel.FromGuess).ToList();

            gameDetailsModel.YourColour = userIsBlue ? "blue" : "red";

            gameDetailsModel.GameState = GetGameState(game.State);

            return gameDetailsModel;
        }

        private static string GetGameState(GameState state)
        {
            switch (state)
            {
                case BullsAndCows.Models.GameState.WaitingForSecondPlayer: return "WaitingForOpponent";
                case BullsAndCows.Models.GameState.BluePlayerTurn: return "BlueInTurn";
                case BullsAndCows.Models.GameState.RedPlayerTurn: return "RedInTurn"; 
                case BullsAndCows.Models.GameState.WonByBluePlayer: return "WonByBluePlayer"; 
                case BullsAndCows.Models.GameState.WonByRedPlayer: return "WonByRedPlayer";
            }

            return "";
        }
    }
}