using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Articles.Models;
using Articles.Data.Repositories;
using System.Linq;
using Articles.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Threading;
using System.Collections.Generic;
using System.Web.Http.Routing;
using Articles.WebApi.Controllers;
using Articles.WebApi.DataModels;

namespace Articles.Tests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetAll_WhenArticlesInDb_ShouldReturnArticles()
        {
            Article[] articles = this.GenerateValidTestArticles(1);

            var repo = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => articles.AsQueryable());

            var data = Mock.Create<IArticlesData>();

            Mock.Arrange(() => data.Articles)
                .Returns(() => repo);

            var controller = new ArticlesController(data);
            this.SetupController(controller);

            var actionResult = controller.All();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleDataModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private Article[] GenerateValidTestArticles(int count)
        {
            Article[] articles = new Article[count];
            var category = new Category()
            {
                Id = 1,
                Title = "Test Category"
            };

            var tags = new Tag[]{
                new Tag(){
                     Id = 1,
                     Name="tag"
                }
            };

            for (int i = 0; i < count; i++)
            {
                var article = new Article
                {
                    Id = i,
                    Title = " Title #" + i,
                    Content = "The Content #" + i,
                    Category = category,
                    DateCreated = DateTime.Now,
                    Tags = tags,
                    Author = new ApplicationUser()
                };
                articles[i] = article;
            }

            return articles;
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
