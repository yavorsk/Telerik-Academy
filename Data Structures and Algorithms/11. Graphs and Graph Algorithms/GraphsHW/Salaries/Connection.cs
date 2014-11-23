using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
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
