using IntroEFCF.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroEFCF.EF
{
    public class StudentContext : DbContext
    {
        //public StudentContext() : base("") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}