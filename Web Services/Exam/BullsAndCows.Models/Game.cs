using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class Game
    {
        public Game()
        {
            this.State = GameState.WaitingForSecondPlayer;
            this.Guesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RedId { get; set; }

        public virtual ApplicationUser Red { get; set; }

        public int RedsNumber { get; set; }

        public string BlueId { get; set; }

        public virtual ApplicationUser Blue { get; set; }

        public int BluesNumber { get; set; }

        public GameState State { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Guess> Guesses { get; set; }
    }
}
