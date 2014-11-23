using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopNews.Models;

namespace TopNews
{
    public partial class News : System.Web.UI.Page
    {
        public TopNewsDbContext dbContext;

        public News()
        {
            this.dbContext = new TopNewsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<TopNews.Models.Article> ListViewPopularArticles_GetData()
        {
            var articles = this.dbContext.Articles.ToList();

            Dictionary<int, int> dictArticleLikes = new Dictionary<int, int>();

            foreach (var article in articles)
            {
                var likes = 0;

                foreach (var like in article.Likes)
                {
                    if (like.Value)
                    {
                        likes++;
                    }
                    else
                    {
                        likes--;
                    }
                }

                dictArticleLikes.Add(article.ID, likes);
            }

            var orderedDictArticleLikes = dictArticleLikes.OrderByDescending(item => item.Value);

            var result = new List<Article>();

            foreach (var pair in orderedDictArticleLikes)
            {
                result.Add(articles.First(a => a.ID == pair.Key));
            }

            return result.Take(3);
        }

        public string GetLikes(Article article)
        {
            int likes = 0;

            foreach (var like in article.Likes)
            {
                if (like.Value)
                {
                    likes++;
                }
                else
                {
                    likes--;
                }
            }

            return likes.ToString();
        }

        public string GetContentPreview(Article article)
        {
            var trimmedContent = article.Content;

            if (trimmedContent.Length > 300)
            {
                return trimmedContent.Substring(0, 300) + "...";
            }
            else
            {
                return trimmedContent;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TopNews.Models.Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.Name);
        }

       public ICollection<Article> GetLatestAticles(Category category)
        {
            var articles = category.Articles.OrderByDescending(a => a.DateCreated).Take(3);

            return articles.ToList();
        }
    }
}