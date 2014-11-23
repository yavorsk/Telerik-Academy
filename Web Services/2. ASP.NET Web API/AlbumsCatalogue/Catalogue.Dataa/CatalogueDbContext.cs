using Catalogue.Dataa.Migrations;
using Catalogue.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Dataa
{
    public class CatalogueDbContext : DbContext, ICatalogueDbContext
    {
        public CatalogueDbContext()
            : base("CatalogueConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CatalogueDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
