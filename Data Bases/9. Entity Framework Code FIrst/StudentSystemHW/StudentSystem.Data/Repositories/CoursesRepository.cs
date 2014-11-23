using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Repositories
{
    public class CoursesRepository : GenericRepository<Course>, IGenericRepository<Course>
    {
        public CoursesRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }

        // additional functionallity for courses data
    }
}
