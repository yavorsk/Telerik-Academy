using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Continents
{
    public partial class Continents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("ala bala");
            this.GridViewCountries.PageIndex = this.ListBoxContinents.SelectedIndex;
            this.GridViewCountries.DataBind();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            this.ListViewCities.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}