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
            um.SortStudentsByAge();
            um.AllStudentsFromBejingTech();




            um.StudentAndUniversityNameCollection();




            /*

           int[] someInt = {30,12,4,3,12 };
           IEnumerable<int> sortedInts = from i in someInt 
                                         orderby i 
                                         select i;

           // reverse my sorted ints
           IEnumerable<int> reversedInts = sortedInts.Reverse();

           foreach (int i in sortedInts) 
           {
               Console.WriteLine(i);
           }

           Console.WriteLine("------------------");

           foreach (int i in reversedInts)
           {
               Console.WriteLine(i);
           }

           IEnumerable<int> reversedSortedInts = from i in someInt
                                                 orderby i descending
                                                 select i;

           Console.WriteLine("------------------");

           foreach (int i in reversedSortedInts)
           {
               Console.WriteLine(i);
           }



            * 
            *  Console.WriteLine("Enter a University ID:" );
           string input = Console.ReadLine();

           try
           {

               int inputAsInt = Convert.ToInt32(input);
               um.AllStudentsFromUserInputUni(inputAsInt);
           }
           catch (Exception ex)
           {
               Console.WriteLine("WRONG VALUE {0}",ex.Message);
           }
           */




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

            public void SortStudentsByAge()
            {
                // orderby is an operator which will sort by the value
                // var is shortcut to not create IEnumerable but makes the running of the code a little bit slower
                var sortedStudents = from student
                                     in students
                                     orderby student.Age select student;


                Console.WriteLine("Students Sorted By Age: " );
                foreach (Student student in sortedStudents)
                {
                    student.Print();
                }


            }
            

            public void AllStudentsFromBejingTech()
            {
                IEnumerable<Student> beijingTechStudents = from student in students
                                                           join university in universities on student.UniversityId equals university.Id
                                                           where university.Name == "Beijing Tech"
                                                           select student;
                Console.WriteLine("Students from Beijing Tech: ");
                foreach (Student stu in beijingTechStudents)
                {
                    stu.Print();
                }
            }

            public void AllStudentsFromUserInputUni(int id)
            {
                IEnumerable<Student> universityStudents = from student in students
                                                          join university in universities on student.UniversityId equals university.Id
                                                          where student.UniversityId == id 
                                                          select student;
                Console.WriteLine($"Students of university with ID: {id}");
                foreach (Student stu in universityStudents)
                {
                    stu.Print();
                }

            }

            public void StudentAndUniversityNameCollection()
            {
                var newCollection = from student in students
                                    join university in universities on student.UniversityId equals university.Id
                                    orderby student.Name
                                    select new { StudentName = student.Name, UniversityName = university.Name };

                Console.WriteLine("New Collection: ");
                foreach (var col in newCollection)
                {
                    Console.WriteLine($"Student {col.StudentName} from university {col.UniversityName}");
                }
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
