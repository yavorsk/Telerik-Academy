using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Wcf.DataModels
{
    public class UserDetailsDataModel
    {
        public static UserDetailsDataModel GetDetailsFromUser(ApplicationUser user)
        {
            return new UserDetailsDataModel
            {
                Id = user.Id,
                Losses = user.Losses,
                Wins = user.Wins,
                Rank = user.Losses * 15 + user.Wins * 100,
                Username = user.UserName
            };
        }

        public string Id {get; set;}

        public int Losses {get; set;}

        public int Wins {get; set;}

        public int Rank {get; set;}

        public string Username {get; set;}
    }
}