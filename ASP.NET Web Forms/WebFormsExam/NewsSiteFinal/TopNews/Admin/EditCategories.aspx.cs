using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopNews.Models;

namespace TopNews.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        public TopNewsDbContext dbContext;

        public EditCategories()
        {
            this.dbContext = new TopNewsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<TopNews.Models.Category> ListViewEditCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.ID);
        }


        public void ListViewEditCategories_DeleteItem(int ID)
        {
            var category = this.dbContext.Categories.Find(ID);
            this.dbContext.Categories.Remove(category);
            this.dbContext.SaveChanges();
        }


        public void ListViewEditCategories_UpdateItem(int ID)
        {
            TopNews.Models.Category item = this.dbContext.Categories.Find(ID);

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

        public void ListViewEditCategories_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.Categories.Add(item);
                this.dbContext.SaveChanges();
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupInsert");
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupEdit");
        }

    }
}