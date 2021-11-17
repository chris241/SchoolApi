using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class SchoolApiContext: DbContext
    {
        public SchoolApiContext(DbContextOptions<SchoolApiContext> options)
            :base(options)
        {

        }
        public DbSet<Course> Courses { get; set;  }
    }
}
