using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebAjax.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

    }
    class StudentsDbContext : DbContext {
        public DbSet<Student> Students { get; set; }
    }
}