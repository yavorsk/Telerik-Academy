using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Wcf.DataModels
{
    public class UserDataModels
    {
        public static Expression<Func<ApplicationUser, UserDataModels>> FromUser
        {
            get
            {
                return u => new UserDataModels
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }

        public string Username { get; set; }

        public string Id { get; set; }
    }
}