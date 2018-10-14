using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using University.Models;

namespace University
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Book> Books { get; set; }

        public StudentsContext() : base("DefaultConnection")
        { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .Map(t => t.MapLeftKey("CourseId")
        //        .MapRightKey("StudentId")
        //        .ToTable("CourseStudent"));
        //}
    }


    public class UnivDbInitializer : DropCreateDatabaseAlways<StudentsContext>
    {
        protected override void Seed(StudentsContext context)
        {
            Student s1 = new Student {Id = 1, Name = "Petrov" };
            Student s2 = new Student { Id = 2, Name = "Sidorov" };
            Student s3 = new Student { Id = 3, Name = "Ivanov" };
            Student s4 = new Student { Id = 4, Name = "Bulkin" };

            context.Students.AddRange(new List<Student>() { s1, s2, s3, s4 });

            Course c1 = new Course()
            {
                Id = 1,
                Name = "Math",
                Students = new List<Student> { s1, s2, s3 }
            };

            Course c2 = new Course()
            {
                Id = 2,
                Name = "Phisics",
                Students = new List<Student> { s2, s3 }
            };
            Course c3 = new Course()
            {
                Id = 3,
                Name = "Litrete",
                Students = new List<Student> { s4, s3 }
            };

            context.Courses.AddRange(new List<Course> { c1, c2, c3 });

            base.Seed(context);

        }
    }
}