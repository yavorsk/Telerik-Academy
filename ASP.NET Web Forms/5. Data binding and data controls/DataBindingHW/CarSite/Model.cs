using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSite
{
    public class Model
    {
        public string Name { get; set; }

        public Model(string name)
        {
            this.Name = name;
        }
    }
}