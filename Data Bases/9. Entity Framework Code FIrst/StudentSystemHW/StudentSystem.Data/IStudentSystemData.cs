using StudentSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentSystem.Data
{
    public interface IStudentSystemData
    {
        StudentsRepository Students { get; }

        CoursesRepository Courses { get; }

        HomeworksRepository Homeworks { get; }
    }
}
