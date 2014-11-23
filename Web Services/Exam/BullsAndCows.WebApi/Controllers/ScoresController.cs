using BullsAndCows.Data;
using BullsAndCows.WebApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BullsAndCows.WebApi.Controllers
{
    public class ScoresController : BaseApiController
    {
        public ScoresController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetHighScore()
        {
            var scoreList = this.data.Users.All()
                .Select(ScoreDataModel.FromUser)
                .OrderByDescending(s => s.Rank)
                .ThenBy(s => s.Username)
                .Take(10).ToList();

            return Ok(scoreList);
        }
    }
}
