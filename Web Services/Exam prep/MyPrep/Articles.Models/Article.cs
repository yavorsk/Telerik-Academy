﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Article
    {
        public Article()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
