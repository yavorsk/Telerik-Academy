using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopNews.Models;

namespace TopNews
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        public TopNewsDbContext dbContext;

        public ArticleDetails()
        {
            this.dbContext = new TopNewsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public TopNews.Models.Article FormViewArticle_GetItem([QueryString("id")]int? id)
        {
            return this.dbContext.Articles.Find(id);
        }

        public int GetLikes(Article article)
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

            return likes;
        }

        public void LikePlus(object sender, EventArgs e)
        {
            if (this.Request.QueryString["id"] != null)
            {
                var currentArticle = this.dbContext.Articles.Find(int.Parse(this.Request.QueryString["id"]));
                currentArticle.Likes.Add(new Like() { Value = true });
                this.dbContext.SaveChanges();
            }
        }

        public void LikeMinus(object sender, EventArgs e)
        {
            if (this.Request.QueryString["id"] != null)
            {
                var currentArticle = this.dbContext.Articles.Find(int.Parse(this.Request.QueryString["id"]));
                currentArticle.Likes.Add(new Like() { Value = false });
                this.dbContext.SaveChanges();
            }
        }
    }
}