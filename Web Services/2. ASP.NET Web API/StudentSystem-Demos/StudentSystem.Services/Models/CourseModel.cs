using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}