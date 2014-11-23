using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage.cs
{
    public class Node
    {
        public HashSet<Node> IncommingConnections { get; set; }

        public HashSet<Connection> Connections { get; set; }

        public Node(char value)
        {
            this.Value = value;
            this.IncommingConnections = new HashSet<Node>();
            this.Connections = new HashSet<Connection>();
            this.CountOfIncomingConnections = 0;
        }

        public char Value { get; set; }
        public int NodeInitialIndex { get; set; }
        public int CountOfIncomingConnections { get; set; }
    }
}
