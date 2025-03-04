using System.Data.Entity;

namespace ModelFirst.Models
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("Server=localhost;Database=SchoolsDB;TrustServerCertificate=True;Integrated Security=true")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class

            modelBuilder.Entity<Course>()
                .ToTable("Course");

            modelBuilder.Entity<Enrollment>()
            .ToTable("Enrollment");

            modelBuilder.Entity<Student>()
            .ToTable("Student");

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
