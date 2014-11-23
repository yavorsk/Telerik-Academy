using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class ScoreDataModel
    {
        public static Expression<Func<ApplicationUser, ScoreDataModel>> FromUser
        {
            get
            {
                return u => new ScoreDataModel
                {
                    Username = u.UserName,
                    Rank = u.Wins * 100 + u.Losses * 15
                };
            }
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}