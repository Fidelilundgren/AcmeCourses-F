using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AcmeCourses;

internal partial class Program
{
    static void Main(string[] args)
    {

        var context = new ApplicationContext();

        while (true)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("          MENU           ");
            Console.WriteLine("=========================");
            Console.WriteLine("E: Education ");
            Console.WriteLine("C: Course");
            Console.WriteLine("S: Student");
            Console.WriteLine("L: Leave");
            Console.WriteLine("Choose an option (E/C/S/L) ");
            char input = char.ToLower(Console.ReadKey(true).KeyChar);

            Console.WriteLine(char.ToUpper(input)); // Display the key in uppercase

            switch (input)
            {
                case 'e':
                    Console.Clear();
                    Console.WriteLine("Education:");

                    var educations = context.Educations
                        .ToList();

                    foreach (var eduation in educations)
                    {
                        Console.WriteLine($" ID: {eduation.Id}, Namn: {eduation.Name}, Beskrivning: {eduation.Description}");
                    }

                    break;

                case 'c':
                    Console.Clear();
                    Console.WriteLine("Course:");

                    var courses = context.Courses
                        .ToList();

                    foreach (var course in courses )
                    {
                        Console.WriteLine($" ID: {course.Id}, Namn: {course.CourseName}, Beskrivning: {course.Description}, Start: {course.StartDate}, Slut: {course.EndDate} ");
                    }
                    break; 

                case 's':
                    Console.Clear();
                    Console.WriteLine("Student:");

                    var students = context.Students
                       .ToList();

                    foreach (var student in students)
                    {
                        Console.WriteLine($" ID: {student.Id}, Förnamn: {student.FirstName}, Efternamn: {student.LastName}");
                    }




                    break;

                case 'l':
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;

                default: // Invalid input
                    Console.Clear();
                    Console.WriteLine("Please enter E/C/S/L!");
                    break;
            }
        }
    }
}
