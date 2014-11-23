using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private decimal currentResult = 0;
        private string activeCommand = string.Empty;
        private bool inputNextNumber = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSqrt.Text = Server.HtmlDecode("&radic;");

            if (this.ViewState["currentResult"] == null)
            {
                this.ViewState.Add("currentResult", 0M);
            }

            if (this.ViewState["activeCommand"] == null)
            {
                this.ViewState.Add("activeCommand", string.Empty);
            }

            if (this.ViewState["inputNextNumber"] == null)
            {
                this.ViewState.Add("inputNextNumber", false);
            }
        }

        protected void btnNum_Command(object sender, CommandEventArgs e)
        {
            if ((bool)this.ViewState["inputNextNumber"])
            {
                this.inputBox.Text = "0";
                this.ViewState["inputNextNumber"] = false;
            }

            if (!(this.inputBox.Text == "0" && e.CommandName == "0"))
            {
                if (this.inputBox.Text == "0")
                {
                    this.inputBox.Text = e.CommandName;
                }
                else
                {
                    this.inputBox.Text += e.CommandName;
                }
            }
        }

        protected void btnOperator_Command(object sender, CommandEventArgs e)
        {
            if (this.ViewState["activeCommand"] == string.Empty)
            {
                this.ViewState["currentResult"] = decimal.Parse(this.inputBox.Text);
                this.ViewState["activeCommand"] = e.CommandName;
                this.ViewState["inputNextNumber"] = true;
            }
            else
            {
                decimal newNum = decimal.Parse(this.inputBox.Text);
                this.ViewState["currentResult"] = Evaluate((decimal)this.ViewState["currentResult"], newNum, (string)this.ViewState["activeCommand"]);
                this.ViewState["activeCommand"] = e.CommandName;
                this.ViewState["inputNextNumber"] = true;
                this.inputBox.Text = ((decimal)this.ViewState["currentResult"]).ToString();
            }
        }

        private decimal Evaluate(decimal num1, decimal num2, string command)
        {
            decimal result = 0;

            switch (command)
            {
                case "plus": result = num1 + num2; break;
                case "minus": result = num1 - num2; break;
                case "multiply": result = num1 * num2; break;
                case "divide": result = num1 / num2; break;
                case "sqrt": result = (decimal)Math.Sqrt((double)num1); break;
            }

            return result;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.inputBox.Text = "0";
            this.ViewState["inputNextNumber"] = false;
            this.ViewState["currentResult"] = 0M;
            this.ViewState["activeCommand"] = string.Empty;
        }

        protected void equalsBtn_Click(object sender, EventArgs e)
        {
            decimal newNum = decimal.Parse(this.inputBox.Text);
            this.ViewState["currentResult"] = Evaluate((decimal)this.ViewState["currentResult"], newNum, (string)this.ViewState["activeCommand"]);
            this.ViewState["activeCommand"] = string.Empty;
            this.ViewState["inputNextNumber"] = false;
            this.inputBox.Text = ((decimal)this.ViewState["currentResult"]).ToString();
            this.ViewState["currentResult"] = 0M;
        }
    }
}