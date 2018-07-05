using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TobeConsolePractise.Mapping_EF
{
    //all made public for Moq framework
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {
        }

        public virtual IDbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual IDbSet<Subject> Subjects { get; set; }
        public virtual IDbSet<EnrollMent> Enrollments { get; set; }
    }

    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Student            
    {
        public Student()
        {
            Enrollments = new List<EnrollMent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AdministratorId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        //public Administrator Administrator { get; set; }
        [ForeignKey("AdministratorId")]
        public virtual Administrator CreatingAdmin { get; set; }

        public virtual ICollection<EnrollMent> Enrollments { get; set; }
    }

    public class Subject
    {
        public Subject()
        {
            Enrollments = new List<EnrollMent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EnrollMent> Enrollments { get; set; }
    }

    public class EnrollMent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
