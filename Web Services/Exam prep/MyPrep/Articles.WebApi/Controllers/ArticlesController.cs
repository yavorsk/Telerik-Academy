using Articles.Data;
using Articles.Models;
using Articles.WebApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Articles.WebApi.Controllers
{
    public class ArticlesController : BaseApiController
    {
        public ArticlesController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult PostArticle(ArticleDataModel articleModel)
        {
            var currentUserID = this.User.Identity.GetUserId();

            var category = GetCategory(articleModel);
            var tags = GetTags(articleModel);

            var newArticle = new Article
            {
                AuthorId = currentUserID,
                CategoryId = category.Id,
                Content = articleModel.Content,
                DateCreated = DateTime.Now,
                Tags = tags,
                Title = articleModel.Title
            };

            this.data.Articles.Add(newArticle);
            this.data.SaveChanges();

            articleModel.Id = newArticle.Id;
            articleModel.DateCreated = newArticle.DateCreated;

            return Ok(articleModel);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(null, 0);
        }

        [HttpGet]
        public IHttpActionResult All(string category)
        {
            return this.All(category, 0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            return this.All(null, page);
        }

        [HttpGet]
        public IHttpActionResult All(string category, int page)
        {
            var articles = this.data.Articles.All().OrderBy(a => a.DateCreated)
                .Where(a => category != null ? a.Category.Title.Equals(category, StringComparison.InvariantCultureIgnoreCase) : true)
                .Skip(page * 10)
                .Take(10)
                .Select(ArticleDataModel.FromArticle).ToList();

            return Ok(articles);
        }

        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            var article = this.data.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new ArticleDetailsDataModel(article);
            return Ok(articleModel);
        }

        private Category GetCategory(ArticleDataModel articleModel)
        {
            var categoryName = articleModel.Category;

            var category = this.data.Categories.All().FirstOrDefault(c => c.Title == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Title = categoryName
                };

                this.data.Categories.Add(category);
            }

            return category;
        }

        private HashSet<Tag> GetTags(ArticleDataModel articleModel)
        {
            HashSet<Tag> tags = new HashSet<Tag>();
            var tagNames = articleModel.Tags;

            foreach (var tagName in tagNames)
            {
                var newTag = this.data.Tags.All().FirstOrDefault(t => t.Name == tagName);

                if (newTag == null)
                {
                    newTag = new Tag { Name = tagName };
                    this.data.Tags.Add(newTag);
                }

                tags.Add(newTag);
            }

            return tags;
        }
    }
}
