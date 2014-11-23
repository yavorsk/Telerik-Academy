using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DocWord : DocOffice, IEncryptable, IEditable
{
    public long? NumberOFCharacters { get; set; }
    public bool IsEncrypted { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

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
        if (key == "chars")
        {
            this.NumberOFCharacters = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("chars", this.NumberOFCharacters));
    }
}
