using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World.Models
{
    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public byte[] Flag { get; set; }

        public int ContinentId { get; set; }
        public virtual Continent Continent { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
