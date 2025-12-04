namespace AcmeCourses;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        // Navigation properties
        public List<Education> Educations { get; set; } = new();
        public List<Student> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = null!;
    }

    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EducationId { get; set; }
        public Education Education { get; set; } = null!;

    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int EducationId { get; set; }
        public Education Education { get; set; } = null!;
    }
}
