using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullsAndCows.WebApi.Controllers
{
    public class NumberDataModel
    {
        [Required]
        [Range(1000, 9999)]
        public int number { get; set; }
    }
}