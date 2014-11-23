using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class CreateGameDataModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int number { get; set; }
    }
}