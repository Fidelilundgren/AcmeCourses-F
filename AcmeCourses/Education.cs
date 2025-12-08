namespace AcmeCourses;

internal partial class Program
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        // Navigation properties
        public List<Student> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = new();

        //public override string ToString()
        //{
        //    return "";
            
        //}

    }
}
