using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopNews.Models
{
    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}