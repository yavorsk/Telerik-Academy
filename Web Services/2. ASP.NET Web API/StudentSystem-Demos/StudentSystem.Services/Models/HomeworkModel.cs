using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    Id = h.Id,
                    Student = h.Student.LastName,
                    Course = h.Course.Name,
                    FileUrl = h.FileUrl,
                    TimeSent = h.TimeSent
                };
            }
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual string Student { get; set; }

        public virtual string Course { get; set; }
    }
}