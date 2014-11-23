using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountOfVisitors
{
    public partial class CountOfVisitors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Application.Lock();

            if (Application["Users"] == null)
            {
                Application["Users"] = 1;
            }
            else
            {
                Application["Users"] = (int)Application["Users"] + 1;
            }

            Application.UnLock();

            this.LabelLoads.Text = Application["Users"].ToString();
        }
    }
}