using StudentSystem.Data.Repositories;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public StudentsRepository Students
        {
            get { return (StudentsRepository)this.GetRepository<Student>(); }
        }

        public CoursesRepository Courses
        {
            get { return (CoursesRepository)this.GetRepository<Course>(); }
        }

        public HomeworksRepository Homeworks
        {
            get { return (HomeworksRepository)this.GetRepository<Homework>(); }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    typeOfRepository = typeof(StudentsRepository);
                }

                if (typeOfModel.IsAssignableFrom(typeof(Course)))
                {
                    typeOfRepository = typeof(CoursesRepository);
                }

                if (typeOfModel.IsAssignableFrom(typeof(Homework)))
                {
                    typeOfRepository = typeof(HomeworksRepository);
                }

                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
