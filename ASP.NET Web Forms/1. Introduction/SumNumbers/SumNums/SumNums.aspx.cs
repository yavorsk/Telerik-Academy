using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNums
{
    public partial class SumNums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOnCalculateSumClick(object sender, EventArgs e)
        {
            try
            {
                double firstNum = double.Parse(this.firstNum.Value);
                double secondNum = double.Parse(this.secondNum.Value);

                double sum = firstNum + secondNum;

                this.result.InnerText = sum.ToString();
            }
            catch (Exception)
            {
                this.result.InnerText = "Invalid Input";
            }
        }
    }
}