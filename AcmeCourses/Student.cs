namespace AcmeCourses;

internal partial class Program
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
