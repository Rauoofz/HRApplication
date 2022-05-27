using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Data
{
    public class AppContext:IdentityDbContext<ApplicationUser>
    {
        public AppContext(DbContextOptions<AppContext>options):base(options)
        {

        }


        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
    }
}
