using CursosSis.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosSis.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasData(
                new Class
                {
                    ClassId = 1,
                    CourseId = 1,
                    ProfessorId = 1,
                    StudentId = 1
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "C# - Iniciante",
                    CourseCode = "CS-I",
                    CoursePrice = 500,
                    CourseType = "EAD"
                }
            );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "João Gabriel",
                    StudentRegNum = 001,
                    StudentTel = "21 09876-5432",
                    StudentEmail = "maninhodoisdois25@gmail.com",
                    StudentDateOfBirth = new DateTime(2008, 03, 16)
                }
            );
            modelBuilder.Entity<Professor>().HasData(
                new Professor
                {
                    ProfessorId = 1,
                    ProfessorName = "Juan Pablo",
                    ProfessorTel = "21 09876-5432",
                    ProfessorEmail = "prof.juanpablo@gmail.com",
                    ProfessorWorkPeriod = "Noite"
                }
            );
        }
    }
}
