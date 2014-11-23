using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlEscaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void displayBtn_Click(object sender, EventArgs e)
        {
            string textToDisplay = this.input.Text;

            this.outputLabel.Text = Server.HtmlEncode(textToDisplay);
            this.outputTextBox.Text = textToDisplay;
            this.outputLiteral.Text = textToDisplay;
        }
    }
}