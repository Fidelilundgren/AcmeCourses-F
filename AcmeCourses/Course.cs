namespace AcmeCourses;

internal partial class Program
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public int EducationId { get; set; }

        public Education Education { get; set; }

    }
}
