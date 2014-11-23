using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExchangeCookies
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                string text = "Hello, " + cookie.Value + "!";
                Response.Write("You are now logged In!");

                LabelLoggedIn.Text = text;
            }
            else
            {
                this.Response.Redirect("~/LoginPage.aspx");
            }
        }
    }
}