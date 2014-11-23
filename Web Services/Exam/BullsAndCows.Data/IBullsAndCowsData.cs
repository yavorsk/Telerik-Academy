using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Data
{
    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<Notification> Notifications { get; }

        //IRepository<UserDetails> UserDetails { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
