using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class GameDataModel
    {
        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Red = g.Red.UserName,
                    Blue = g.Blue != null ? g.Blue.UserName : "No blue player yet",
                    GameState = g.State.ToString(),
                    DateCreated = g.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

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