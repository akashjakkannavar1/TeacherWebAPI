using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TeacherAPI.Models;
using TeacherAPI.Services;

namespace TeacherAPI.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController: ControllerBase
    {
        public TeacherController(TeacherService teacherService)
        {
            TeacherService = teacherService?? throw new ArgumentNullException(nameof(teacherService));
        }
        public TeacherService TeacherService { get; }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            try
            {

                var teacher = TeacherService.Get();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{name}")]
        public ActionResult GetBy([FromRoute]string name)
        {
            try
            {
                
                var teacher = TeacherService.GetById(name);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] Teacher teacher)
        {
            try
            {
                return Ok(TeacherService.Create(teacher));
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{name}")]
        public ActionResult Delete([FromRoute] String name)
        {
            try
            {
                return Ok(TeacherService.Remove(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update( Teacher teacher)
        {
            var book = TeacherService.GetById(teacher._id);

            if (book == null)
            {
                return NotFound();
            }

            TeacherService.Update(teacher._id, teacher);

            return Ok(teacher);
        }

    }
}
