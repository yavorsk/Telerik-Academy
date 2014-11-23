using BullsAndCows.Data.Migrations;
using BullsAndCows.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Data
{
    public class BullsAndCowsDbContext : IdentityDbContext<ApplicationUser>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        IDbSet<Game> Games { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        //IDbSet<UserDetails> UserDetails { get; set; }

        IDbSet<Guess> Guesses { get; set; }
    }
}
