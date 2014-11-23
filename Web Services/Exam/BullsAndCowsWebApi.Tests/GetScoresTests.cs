using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Models;
using Telerik.JustMock;
using BullsAndCows.Data.Repositories;
using BullsAndCows.Data;
using BullsAndCows.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using BullsAndCows.WebApi.DataModels;

namespace BullsAndCowsWebApi.Tests
{
    [TestClass]
    public class GetScoresTests
    {
        [TestMethod]
        public void GetHighScore_WhenUsersWIthRaksArePresentInDb_ShouldReturnRanks()
        {
            ApplicationUser[] users = this.GenerateValidTestUsers(5);

            var repo = Mock.Create<IRepository<ApplicationUser>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => users.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => data.Users)
                .Returns(() => repo);

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetHighScore();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ScoreDataModel>>().Result.Select(s => s.Rank).ToList();

            var expected = users.AsQueryable().Select(u => u.Rank).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetHighScore_WhenUsersWIthRaksArePresentInDb_TheUserWithMaxRankShouldBeFirst()
        {
            ApplicationUser[] users = this.GenerateValidTestUsers(5);

            var repo = Mock.Create<IRepository<ApplicationUser>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => users.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => data.Users)
                .Returns(() => repo);

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetHighScore();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ScoreDataModel>>().Result.Select(s => s.Rank).ToList().First();

            var expected = users.AsQueryable().Select(u => u.Rank).ToList().Max();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHighScore_WhenMoreThan10UsersArePresent_ShouldReturn10entries()
        {
            ApplicationUser[] users = this.GenerateValidTestUsers(15);

            var repo = Mock.Create<IRepository<ApplicationUser>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => users.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => data.Users)
                .Returns(() => repo);

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetHighScore();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ScoreDataModel>>().Result.Select(s => s.Rank).ToList().Count;

            Assert.AreEqual(10, actual);
        }

        private ApplicationUser[] GenerateValidTestUsers(int count)
        {
            ApplicationUser[] users = new ApplicationUser[count];
            
            for (int i = 0; i < count; i++)
            {
                var user = new ApplicationUser
                {
                    Id = "asdfdsfa" + i,
                    UserName = "Pesho " + i,
                    Wins = i,
                    Losses = i
                };
                user.Rank = user.Wins * 100 + user.Losses * 15;

                users[i] = user;
            }

            return users;
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "articles" }
                    });
        }
    }
}
