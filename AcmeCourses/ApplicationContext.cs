using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AcmeCourses;

internal partial class Program
{
    public class ApplicationContext : DbContext
    {
        // Exponerar våra entiteter som DbSet
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("AppSettings.json")
            .Build();
            // Läs vår connection-string från konfigurations-filen
            var connStr = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Specificerar vilken collation databasen ska använda
            modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

            // Specificerar data som en specifik tabell ska för-populeras med
            modelBuilder.Entity<Education>().HasData(
            new Education { Id = 1, Name = "Backendutvecklare", 
                Description = "En kombination utav teknik och programmering." },
            new Education { Id = 2, Name = "Frontendutvecklare", 
                Description = "En kombination utav användarvänliga och visuella webbplatser." },
            new Education { Id = 3, Name = "Digital kommunikatör", 
                Description = "För framtidens dynamiska kommunikationslandskap." });

            modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, CourseName = "Programmering C#.NET", 
                Description = "Grundkurs C#.", StartDate = DateOnly.Parse("2025-08-25"), 
                EndDate = DateOnly.Parse("2025-10-15"), EducationId = 1 },
            new Course { Id = 2, CourseName = "SQL", 
                Description = "Databas och Databasdesign", 
                StartDate = DateOnly.Parse("2025-10-20"), 
                EndDate = DateOnly.Parse("2025-10-15"), EducationId = 1 },

            new Course { Id = 3, CourseName = "UX", 
                Description = "Grafisk Design", StartDate = DateOnly.Parse("2026-08-20"), 
                EndDate = DateOnly.Parse("2026-10-15"), EducationId = 2 },
            new Course { Id = 4, CourseName = "AI/ChatGPT", 
                Description = "AI för programmerare", 
                StartDate = DateOnly.Parse("2026-10-22"), 
                EndDate = DateOnly.Parse("2026-12-11"), EducationId = 2 },

            new Course { Id = 5, CourseName = "Analys och Rapport", 
                Description = "Analysera marknadsdata", 
                StartDate = DateOnly.Parse("2026-10-20"), 
                EndDate = DateOnly.Parse("2026-12-13"), EducationId = 3 },
            new Course { Id = 6, CourseName = "LIA", 
                Description = "Praktik", StartDate = DateOnly.Parse("2026-12-15"), 
                EndDate = DateOnly.Parse("2027-01-11"), EducationId = 3});

            modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Fideli", LastName = "Lundgren", EducationId = 1 },
            new Student { Id = 2, FirstName = "Niklas", LastName = "Kääpä", EducationId = 2 },
            new Student { Id = 3, FirstName = "Joakim", LastName = "Christiansson", EducationId = 3 },
            new Student { Id = 4, FirstName = "Ruhollah", LastName = "Karim", EducationId = 2 });
            
           

        }
    }
}
