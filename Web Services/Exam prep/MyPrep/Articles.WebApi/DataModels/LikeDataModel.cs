using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WebApi.DataModels
{
    public class LikeDataModel
    {
        public static Expression<Func<Like, LikeDataModel>> FromLike
        {
            get
            {
                return like => new LikeDataModel
                {
                    ID = like.Id,
                    DateCreated = like.DateCreated,
                    AuthorName = like.User.UserName
                };
            }
        }

        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}
