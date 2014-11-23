using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZipFileUpload
{
    public partial class FileUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            Response.Expires = -1;
            try
            {
                if (this.FileUploadControl.HasFile)
                {
                    HttpPostedFile file = FileUploadControl.PostedFile;

                    ZipFile zipFile = ZipFile.Read(file.InputStream);
                    

                    foreach (var zipEntry in zipFile.Entries)
                    {
                        StringBuilder zipContent = new StringBuilder();

                        MemoryStream memoryStream = new MemoryStream();
                        zipEntry.Extract(memoryStream);

                        memoryStream.Position = 0;
                        StreamReader reader = new StreamReader(memoryStream);
                        zipContent.AppendLine(reader.ReadToEnd());
                        zipContent.AppendLine();

                        Label label = new Label();
                        label.Text=zipContent.ToString();

                        this.Controls.Add(label);
                        this.Controls.Add(new LiteralControl("<br />"));
                    }

                    this.StatusLabel.Text = "File Uploaded";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}