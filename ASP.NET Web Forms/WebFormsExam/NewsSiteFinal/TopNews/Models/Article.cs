using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopNews.Models
{
    public class Article
    {
        public Article()
        {
            this.Likes = new HashSet<Like>();
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorID { get; set; } 

        public virtual AppUser Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public DateTime DateCreated { get; set; }
    }
}