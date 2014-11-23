using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    public class Node //: IComparable
    {
        public List<int> IndexesOfEmps { get; set; }

        public List<Node> DirectEmployees { get; set; }

        public List<Connection> Connections { get; set; }

        public Node()
        {
            this.IndexesOfEmps = new List<int>();
            this.DirectEmployees = new List<Node>();
            this.Connections = new List<Connection>();
            this.CountOfIncomingConnections = 0;
        }

        public int Salary { get; set; }
        public int NodeInitialIndex { get; set; }
        public int CountOfIncomingConnections { get; set; }
    }
}
