using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// By using a LINQ Query Operation you can get data from different types of data sources
// Arrays, Databases, XML files and many more sources are valid for a query operation

// Example usage: You should print out the entries of a string array sorted by name

// Three parts of a query operation:
// 1. obtain a data source
// 2. create the query
// 3. execute the query



namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
            um.FemaleStudents();


            

            Console.ReadKey();
        }

        class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;


            // Constructor
            public UniversityManager()
            {
                universities = new List<University>();
                students = new List<Student>();

                // Let's add some Universities
                universities.Add(new University { Id = 1, Name = "Yale" });
                universities.Add(new University { Id = 2, Name = "Beijing Tech" });

                // Let's add some Students
                students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
                students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
                students.Add(new Student { Id = 6, Name = "Frank", Gender = "male", Age = 28, UniversityId = 1 });
                students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
                students.Add(new Student { Id = 4, Name = "James", Gender = "male", Age = 25, UniversityId = 2 });
                students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
            }

            public void MaleStudents()
            {
                IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Male - Students: ");
                foreach (Student student in maleStudents)
                {
                    student.Print();
                }
                Console.ResetColor();
               
            }

            public void FemaleStudents()
            {
                IEnumerable<Student> femaleStudents = from student in students where student.Gender.ToLower() == "female" select student;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Female - Students: ");
                foreach (Student student in femaleStudents)
                {
                    student.Print();
                }
                Console.ResetColor();
            }
        }

        class University
        {
            public int Id { get; set; }
            public string Name { get; set; }


            public void Print()
            {
                Console.WriteLine("University {0} with Id: {1}", Name,Id);
            }

        }


        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Gender { get; set; }

            public int Age { get; set; }

            // Foriegn Key
            public int UniversityId { get; set; }

            public void Print()
            {
                Console.WriteLine("Student {0} with Id {1}, Gender {2} and Age {3} from University with the Id: {4}", Name, Id, Gender, Age, UniversityId);
            }

        }

        
    }
}
