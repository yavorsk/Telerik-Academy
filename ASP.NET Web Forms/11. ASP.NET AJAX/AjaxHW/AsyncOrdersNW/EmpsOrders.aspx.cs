﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsyncOrdersNW
{
    public partial class EmpsOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdatePanelOrders_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
        }
    }
}