using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Data.Migrations;
using World.Models;

namespace World.Data
{
    public class WorldContext : DbContext
    {
        public WorldContext()
            : base("WorldConnectionStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldContext, Configuration>());
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
