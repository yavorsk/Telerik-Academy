using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank: WarMachine, ITank
    {
        private bool defenseMode = false;
        private const double tankInitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = tankInitialHealthPoints;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set { this.defenseMode = value;  }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else if (!this.DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.Append(" *Defense: ");

            if (this.DefenseMode)
            {
                result.AppendLine("ON");
            }
            else
            {
                result.AppendLine("OFF");
            }

            return result.ToString();
        }
    }
}
