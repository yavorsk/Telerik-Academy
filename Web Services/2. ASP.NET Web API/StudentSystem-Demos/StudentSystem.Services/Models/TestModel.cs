using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class TestModel
    {
        public static Expression<Func<Test, TestModel>> FromTest
        {
            get
            {
                return t => new TestModel
                {
                    Id = t.Id,
                    Course = t.Course.Name,
                };
            }
        }

        public int Id { get; set; }

        public virtual string Course { get; set; }
    }
}