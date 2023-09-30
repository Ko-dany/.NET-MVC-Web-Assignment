using Microsoft.EntityFrameworkCore;

namespace Assignment_1_Dahyun_Ko.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { }
        
        public DbSet<Student> Students { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student(1, "Bart", "Simpson", new DateTime(1971, 5, 31), 2.7), 
                new Student(2, "Lisa", "Simpson", new DateTime(1973, 8, 5), 4.0),
                new Student(3, "Kyle", "Choi", new DateTime(1996, 9, 10), 3.7)
                ) ;
        }
    }
}
