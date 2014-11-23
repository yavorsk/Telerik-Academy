namespace World.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using World.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<World.Data.WorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(World.Data.WorldContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var australia = new Continent()
            {
                Name = "Australia",
                Countries = new List<Country>() 
                {
                    new Country() 
                    {
                        Name = "Australia",
                        Language = "English",
                        Cities = new List<City> () 
                        {
                            new City() 
                            {
                                Name = "Sydney",
                                Population = 8979880
                            },
                            new City()
                            {
                                Name = "Brisbane",
                                Population = 162531
                            },
                            new City()
                            {
                                Name = "Melbourne",
                                Population = 654654
                            }
                            
                        }
                    }
                }
            };


            var europe = new Continent()
            {
                Name = "Europe",
                Countries = new List<Country>() 
                {
                    new Country() 
                    {
                        Name = "Bulgaria",
                        Language = "Bulgarian",
                        Cities = new List<City> () 
                        {
                            new City() 
                            {
                                Name = "Sofia",
                                Population = 111111
                            },
                            new City()
                            {
                                Name = "Varna",
                                Population = 1212121
                            },
                            new City()
                            {
                                Name = "Bourgas",
                                Population = 333654
                            }
                            
                        }
                    },
                    new Country() 
                    {
                        Name = "Germany",
                        Language = "Greman",
                        Cities = new List<City> () 
                        {
                            new City() 
                            {
                                Name = "Berlin",
                                Population = 900000
                            },
                            new City()
                            {
                                Name = "Frankfurt",
                                Population = 646464
                            },
                            new City()
                            {
                                Name = "Bonn",
                                Population = 444454
                            }
                            
                        }
                    } ,
                    new Country() 
                    {
                        Name = "England",
                        Language = "English",
                        Cities = new List<City> () 
                        {
                            new City() 
                            {
                                Name = "London",
                                Population = 9564454
                            },
                            new City()
                            {
                                Name = "Manchester",
                                Population = 1464642
                            },
                            new City()
                            {
                                Name = "Dover",
                                Population = 442254
                            }
                            
                        }
                    }
                }
            };

            context.Continents.Add(australia);
            context.Continents.Add(europe);
            context.SaveChanges();
        }
    }
}
