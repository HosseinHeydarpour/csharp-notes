using System.Collections;

namespace ListsApp
{
    internal class Program
    {
        // Key            -> Value
        // Auto in German -> Car in English



        static void Main(string[] args)
        {

            // for using hash table we must declare -> using System.Collections;
            Hashtable studentsTable = new Hashtable();


            Student stud1 = new Student(1, "Hossein", 98);
            Student stud2 = new Student(2, "Maria", 85);
            Student stud3 = new Student(3, "Pinga", 32);
            Student stud4 = new Student(4, "Armas", 78);

            studentsTable.Add(stud1.Id, stud1);
            studentsTable.Add(stud2.Id, stud2);
            studentsTable.Add(stud3.Id, stud3);
            studentsTable.Add(stud4.Id, stud4);
            

            // fetching entries from our hash table

            // the vlaue is and object but we cannot store an object into Student object so we have to cast it 
            // retrieve individual item with known ID
            Student storedStudent = (Student)studentsTable[stud1.Id];

            // retrieve all values form a Hashtable
            foreach (DictionaryEntry entry in studentsTable)
            {
                //Console.WriteLine(entry.Key);
                Student temp = (Student)entry.Value;

                Console.WriteLine("Student ID: {0}",temp.Id);
                Console.WriteLine("Student Name: {0}", temp.Name);
                Console.WriteLine("Student GPA: {0}", temp.GPA);
            }

            Console.WriteLine("\n--------------------------\n");
            // Go through values of the hash table directly
            foreach (Student value in studentsTable.Values)
            {
                Console.WriteLine("Student ID: {0}", value.Id);
                Console.WriteLine("Student Name: {0}", value.Name);
                Console.WriteLine("Student GPA: {0}", value.GPA);
            }

            //Console.WriteLine("Student Id: {0}, Name: {1}, GPA: {2}", storedStudent.Id, storedStudent.Name, storedStudent.GPA);




            Console.ReadLine();
        }


        class Student
        {
            // Prop called id
            public int Id { get; set; }

            //Prop called name
            public string Name { get; set; }

            // Prop called GPA
            public float GPA { get; set; }

            // Simple constructor
            public Student(int id, string name, float GPA) { 
            
                this.Id = id;
                this.Name = name;
                this. GPA = GPA;

            }
        }
    }
}