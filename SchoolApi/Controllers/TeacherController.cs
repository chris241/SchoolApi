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
    public class TeacherController : ControllerBase
    {
        private readonly SchoolApiContext _context;
        public TeacherController(SchoolApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetListTeacher()
        {
            var teachers = _context.Teachers.ToList();
            return teachers;
        }

    }
}
