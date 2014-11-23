using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IpAndBrowser
{
    public partial class IpAndBrowser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralOutput.Text = "IP address: " + Request.UserHostAddress + "<br />";
            this.LiteralOutput.Text += "Browser type: " + Request.Browser.Type + "<br />";
            this.LiteralOutput.Text += "Browser type: " + Request.UserAgent + "<br />";
        }
    }
}