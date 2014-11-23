using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KeepAllEnteredTexts
{
    public partial class AllEnteredText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.Session["EnteredText"] == null)
            {
                this.Session["EnteredText"] = new List<string>();
            }

            var enteredLines = this.Session["EnteredText"] as List<string>;

            this.OutputLabel.Text = "";

            foreach (var line in enteredLines)
            {
                this.OutputLabel.Text += line + "<br/>";
            }
        }

        protected void ButtonAddLine_Click(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text.Trim() != string.Empty)
            {
                (this.Session["EnteredText"] as List<string>).Add(this.InputTextBox.Text);
            }
        }
    }
}