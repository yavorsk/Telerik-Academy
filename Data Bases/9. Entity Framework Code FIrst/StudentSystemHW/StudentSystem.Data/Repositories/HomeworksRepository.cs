using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Repositories
{
    public class HomeworksRepository : GenericRepository<Homework>, IGenericRepository<Homework>
    {
        public HomeworksRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }

        // additional functionallity for homeworks data
    }
}
