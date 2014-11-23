using StudentSystem.Data;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data.Students
                .All()
                .Select(StudentModel.FromStudent);
            
            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data.Students
                .All()
                .Where(s => s.StudentIdentification == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Student with such id doesn not exist.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Students.Add(student);
            this.data.SaveChanges();

            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult UpdateLevel(int level, int id)
        {
            var existingStudent = this.data.Students.All()
                .Where(s => s.StudentIdentification == id)
                .FirstOrDefault();
            if (existingStudent == null)
            {
                return BadRequest("Student with such id does not exist.");
            }

            existingStudent.Level = level;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students
                .All()
                .Where(s => s.StudentIdentification == id)
                .FirstOrDefault();
            if (existingStudent == null)
            {
                return BadRequest("Student with such id does not exist.");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
