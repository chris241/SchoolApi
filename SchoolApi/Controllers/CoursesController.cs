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
        public CoursesController( SchoolApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            var courses = _context.Courses.ToList();
            return courses;
        }
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "C#", "Sql" };
        }*/
    }
}
