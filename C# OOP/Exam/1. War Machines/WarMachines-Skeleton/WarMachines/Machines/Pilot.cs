using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot: IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException();
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name + " - ");

            switch (this.machines.Count)
            {
                case 0: result.Append("no machines"); break;
                case 1:
                    {
                        result.AppendLine("1 machine");
                        result.Append(this.machines[0].ToString());
                        break;
                    }
                default:
                    {
                        result.AppendLine(this.machines.Count + " machines");

                        var sortedMachines = this.machines.OrderBy(machine => machine.HealthPoints).ThenBy(machine => machine.Name);

                        foreach (var machine in sortedMachines)
                        {
                                 result.Append(machine.ToString());
                        }
                    }
                    break;
            }
            
            return result.ToString();
        }
    }
}
