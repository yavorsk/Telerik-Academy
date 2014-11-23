using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxPhotoAlbum
{
    public partial class PhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[4];

            imgSlide[1] = new AjaxControlToolkit.Slide("img/burgas.jpg", "burgas", "Burgas");
            imgSlide[2] = new AjaxControlToolkit.Slide("img/dubai.jpg", "dubai", "Dubai");
            imgSlide[0] = new AjaxControlToolkit.Slide("img/london.jpg", "london", "London");
            imgSlide[3] = new AjaxControlToolkit.Slide("img/newyork.jpg", "newyork", "Newyork");
            imgSlide[4] = new AjaxControlToolkit.Slide("img/paris.jpg", "paris", "Paris");
            imgSlide[5] = new AjaxControlToolkit.Slide("img/varna.jpg", "varna", "Varna");

            return (imgSlide);
        }
    }
}