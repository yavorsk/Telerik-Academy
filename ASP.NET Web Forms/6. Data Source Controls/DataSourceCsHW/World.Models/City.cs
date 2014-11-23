using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
