using Articles.Data.Repositories;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Data
{
    public interface IArticlesData
    {
        IRepository<Article> Articles { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Like> Likes { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
