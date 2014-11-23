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
    public class HomeworkController : ApiController
    {
        private IStudentSystemData data;

        public HomeworkController()
            : this(new StudentsSystemData())
        {
        }

        public HomeworkController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data.Homeworks
                .All()
                .Select(HomeworkModel.FromHomework);

            return Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.data.Homeworks
                .All()
                .Where(h => h.Id == id)
                .Select(HomeworkModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return BadRequest("Homework with such id doesn not exist.");
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Homeworks.Add(homework);
            this.data.SaveChanges();

            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.data.Homeworks
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefault();
            if (existingHomework == null)
            {
                return BadRequest("Homework with such id does not exist.");
            }

            this.data.Homeworks.Delete(existingHomework);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
