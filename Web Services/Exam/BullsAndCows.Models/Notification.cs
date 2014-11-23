using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class Notification
    {
        public Notification()
        {
            this.State = NotificationState.Unread;
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationState State { get; set; }

        public NotificationType Type { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
