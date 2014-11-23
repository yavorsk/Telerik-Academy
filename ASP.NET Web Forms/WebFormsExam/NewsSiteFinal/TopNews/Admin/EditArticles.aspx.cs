using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopNews.Models;
using Microsoft.AspNet.Identity;

namespace TopNews.Admin
{
    public partial class EditArticles : System.Web.UI.Page
    {
        public TopNewsDbContext dbContext;

        public EditArticles()
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
        public IQueryable<TopNews.Models.Article> ListViewEditArticles_GetData()
        {
            return this.dbContext.Articles.OrderBy(a => a.ID);
        }

        public IQueryable<TopNews.Models.Category> DropDownListCategoriesCreate_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.ID);
        }

        public void ListViewEditArticles_DeleteItem(int ID)
        {
            var article = this.dbContext.Articles.Find(ID);
            this.dbContext.Articles.Remove(article);
            this.dbContext.SaveChanges();
        }

        public void ListViewEditArticles_UpdateItem(int ID)
        {
            TopNews.Models.Article item = this.dbContext.Articles.Find(ID);

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ID));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
            }
        }

        public void ListViewEditArticles_InsertItem()
        {
            var newArticle = new Article();
            TryUpdateModel(newArticle);

            if (ModelState.IsValid)
            {
                newArticle.DateCreated = DateTime.Now;
                newArticle.AuthorID = this.User.Identity.GetUserId();

                this.dbContext.Articles.Add(newArticle);
                this.dbContext.SaveChanges();
            }
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

        protected void LinkButtonInsertNewArticle_Click(object sender, EventArgs e)
        {
            this.ListViewEditArticles.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void LinkButtonInsertArticleCancel_Click(object sender, EventArgs e)
        {
            this.ListViewEditArticles.InsertItemPosition = InsertItemPosition.None;
        }
    }
}