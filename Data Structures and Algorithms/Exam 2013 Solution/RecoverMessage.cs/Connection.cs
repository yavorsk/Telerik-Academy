using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage.cs
{
    public class Connection
    {
        public Connection(Node node)
        {
            this.Node = node;
        }

        public Node Node { get; set; }
    }
}
