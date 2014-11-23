using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExchangeCookies
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserName", "Pesho");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
            Response.Redirect("~/SecondPage.aspx");
        }
    }
}