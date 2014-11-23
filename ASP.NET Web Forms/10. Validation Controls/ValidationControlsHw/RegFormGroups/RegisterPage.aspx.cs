using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterForm
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitaAddressInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupAddressInfo");
            if (this.Page.IsValid)
            {
                this.LabelLoginInfoValid.Text = "Address info is valid.";
            }
        }

        protected void ButtonSubmitPersonalInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupPersonalInfo");
            if (this.Page.IsValid)
            {
                this.LabelLoginInfoValid.Text = "Personal info is valid.";
            }
        }

        protected void ButtonSubmitLoginInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLoginInfo");
            if (this.Page.IsValid)
            {
                this.LabelLoginInfoValid.Text = "Login info is valid.";
            }
        }
    }
}