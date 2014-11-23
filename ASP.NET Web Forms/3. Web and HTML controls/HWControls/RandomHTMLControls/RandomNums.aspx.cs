using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomHTMLControls
{
    public partial class RandomNums : System.Web.UI.Page
    {
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void generateRandom_Click(object sender, EventArgs e)
        {
            try
            {
                int lowerBound = int.Parse(this.lowBoundInput.Value);
                int upperBound = int.Parse(this.upBoundInput.Value);

                this.output.Value = this.rand.Next(lowerBound, upperBound + 1).ToString();
            }
            catch (Exception)
            {
                this.output.Value = "Please eneter integer numbers!";
            }
        }
    }
}