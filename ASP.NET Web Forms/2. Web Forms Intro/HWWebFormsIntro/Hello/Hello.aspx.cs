using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hello
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void printBtn_Click(object sender, EventArgs e)
        {
            string name = this.inputName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                this.output.Text = "Please enter some name in the textbox!";
            }
            else
            {
                this.output.Text = string.Format("Hello {0}!", name);
            }
        }
    }
}