using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMdb.Model
{
    public class CardAccount
    {
        [Key]
        public int CardAccountId { get; set; }

        [MaxLength(10)]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
