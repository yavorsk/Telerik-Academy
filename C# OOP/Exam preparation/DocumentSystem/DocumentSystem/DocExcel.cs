using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DocExcel: DocOffice, IEncryptable
{
    public int? Rows { get; set; }
    public int? Cols { get; set; }
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
        if (key == "rows")
        {
            this.Rows = int.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
    }
}
