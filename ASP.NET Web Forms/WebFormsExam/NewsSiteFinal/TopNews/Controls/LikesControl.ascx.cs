using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopNews.Controls
{
    public partial class LikesControl : System.Web.UI.UserControl
    {
        [Category("Bahavior")]
        [Description("This is the numeric value shown in the box.")]
        public int Value
        {
            get
            {
                try
                {
                    int value = Int32.Parse(this.LabelLikesCount.Text);
                    return value;
                }
                catch (Exception)
                {
                    return 1;
                }
            }

            set
            {
                string oldText = this.LabelLikesCount.Text;
                string newText = value.ToString(CultureInfo.InvariantCulture);
                this.LabelLikesCount.Text = newText;

                if (int.Parse(oldText) > int.Parse(newText))
                {
                    if (this.LikeDown != null)
                    {
                        this.LikeDown(this, EventArgs.Empty);
                    }
                }

                if (int.Parse(oldText) < int.Parse(newText))
                {
                    if (this.LikeUp != null)
                    {
                        this.LikeUp(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler LikeUp;

        public event EventHandler LikeDown;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelLikesCount.Text = this.Value.ToString();
        }

        protected void ButtonDislike_Click(object sender, EventArgs e)
        {
            this.Value--;
        }

        protected void ButtonLike_Click(object sender, EventArgs e)
        {
            this.Value++;
        }
    }
}