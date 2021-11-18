using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolApiContext _context;
        public CoursesController(SchoolApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            var courses = _context.Courses.ToList();
            return courses;
        }
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course cours)
        {
            var course = _context.Courses.Add(cours);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourseById), new { id = cours.Id }, cours);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if( course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "C#", "Sql" };
        }*/
    }
}
