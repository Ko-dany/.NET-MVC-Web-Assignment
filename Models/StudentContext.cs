using Microsoft.EntityFrameworkCore;

namespace Assignment_1_Dahyun_Ko.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { }
        
        public DbSet<Student> Students { get; set;}
        public DbSet<Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Bart",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1971, 5, 31),
                    GPA = 2.7,
                    ProgramId = "CP"
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 8, 5),
                    GPA = 4.0,
                    ProgramId = "BACS"
                },
                new Student
                {
                    StudentId = 3,
                    FirstName = "Maggie",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1996, 9, 10),
                    GPA = 3.1,
                    ProgramId = "CPA"
                }

                );
            modelBuilder.Entity<Program>().HasData(
                new Program { ProgramId = "CP", Name = "Computer Programming" },
                new Program { ProgramId = "CPA", Name = "Computer Programming and Analysis" },
                new Program { ProgramId = "ITID", Name = "IT Innovation and Design" },
                new Program { ProgramId = "SET", Name = "Software Engineering Technology" },
                new Program { ProgramId = "BACS", Name = "Bachelor of Applied Computer Science" }
                );
        }
    }
}
