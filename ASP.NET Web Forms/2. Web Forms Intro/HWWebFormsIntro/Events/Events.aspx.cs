using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Events
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page PreInit event invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page Init event invoked" + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page Load event invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page PreRender event invoked" + "<br/>");
        }

        protected void telerikNinja_init(object sender, EventArgs e)
        {
            Response.Write("Image init event invoked" + "<br/>");
        }

        protected void telerikNinja_Click(object sender, EventArgs e)
        {
            Response.Write("Image click event invoked" + "<br/>");
        }

        protected void telerikNinja_Load(object sender, EventArgs e)
        {
            Response.Write("Image load event invoked" + "<br/>");
        }

        protected void telerikNinja_PreRender(object sender, EventArgs e)
        {
            Response.Write("Image preRender event invoked" + "<br/>");
        }
    }
}