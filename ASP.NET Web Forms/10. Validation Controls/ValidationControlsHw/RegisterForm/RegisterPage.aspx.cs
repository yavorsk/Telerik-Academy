﻿using System;
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

        protected void ValidatorCheckBox_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAccept.Checked;
        }
    }
}