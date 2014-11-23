using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystem.Services.Controllers
{
    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data.Courses
                .All()
                .Select(CourseModel.FromCourse);

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult ById(string id)
        {
            var course = this.data.Courses
                .All()
                .Where(c => c.Id.ToString() == id)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return BadRequest("Course with such id doesn not exist.");
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(Course course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Courses.Add(course);
            this.data.SaveChanges();

            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var existingCourse = this.data.Courses
                .All()
                .Where(c => c.Id.ToString() == id)
                .FirstOrDefault();
            if (existingCourse == null)
            {
                return BadRequest("Course with such id does not exist.");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
