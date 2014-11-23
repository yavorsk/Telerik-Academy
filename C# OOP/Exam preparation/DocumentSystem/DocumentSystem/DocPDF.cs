using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DocPDF : DocBinary, IEncryptable
{
    public int? NumberOfPages { get; set; }
    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        if (!IsEncrypted)
        {
            IsEncrypted = true;
        }
    }

    public void Decrypt()
    {
        if (IsEncrypted)
        {
            IsEncrypted = false;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.NumberOfPages = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
    }

}
