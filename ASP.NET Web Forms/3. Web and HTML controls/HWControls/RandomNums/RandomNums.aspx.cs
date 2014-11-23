using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNums
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
                int lowerBound = int.Parse(this.lowBoundInput.Text);
                int upperBound = int.Parse(this.upBoundInput.Text);

                this.output.Text = this.rand.Next(lowerBound, upperBound + 1).ToString();
            }
            catch (Exception)
            {
                this.output.Text = "Please eneter integer numbers!";
            }
        }
    }
}