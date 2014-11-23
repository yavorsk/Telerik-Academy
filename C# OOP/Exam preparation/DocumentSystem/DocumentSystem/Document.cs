using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Key '" + key + "' not found!");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> fileProperties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(fileProperties);

        StringBuilder fileInfo = new StringBuilder();

        fileInfo.Append(this.GetType().Name);
        fileInfo.Append("[");

        fileProperties.OrderBy(prop => prop.Key);

        bool firstProp = true;

        foreach (var prop in fileProperties)
        {
            if (!firstProp)
            {
                fileInfo.Append(";");
            }
            if (prop.Value != null)
            {
                fileInfo.AppendFormat("{0}={1}", prop.Key, prop.Value.ToString());
                firstProp = false;
            }
        }

        return fileInfo.ToString();
    }
}
