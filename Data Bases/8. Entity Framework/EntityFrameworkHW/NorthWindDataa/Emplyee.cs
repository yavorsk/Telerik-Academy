﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace NorthWindDataa
{
    public partial class Employee
    {
        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;

                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();

                entityTerritories.AddRange(employeeTerritories);

                return entityTerritories;
            }
        }
    }
}
