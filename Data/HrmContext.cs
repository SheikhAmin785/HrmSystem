using HrmSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Data
{
    public class HrmContext:DbContext
    {

        public HrmContext(DbContextOptions<HrmContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Increment> Increments { get; set; }
       
    }
}
