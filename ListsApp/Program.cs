using System.Collections;

namespace ListsApp
{
    internal class Program
    {

        class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public int Salary { get; set; }

            public Employee(string name, int age, int salary) 
            { 
                Name = name;
                Age = age;
                Salary = salary;
            }
        }
        


        static void Main(string[] args)

        {

            // key - value
            // key is unique and only exists once
            // Key cannot be null nad also cannot be nullable type
            // Declaring and initializing a Dictionary
            Dictionary<int,Employee> employees = new Dictionary<int,Employee>();

            employees.Add(1, new Employee("Ned Stark", 42, 100000));
            employees.Add(2, new Employee("Rob Stark", 20, 95000));
            employees.Add(3, new Employee("Sansa Stark", 15, 30000));
            employees.Add(4, new Employee("Arya Stak", 8, 5000));
            employees.Add(5, new Employee("Katlyin Stark", 35, 200000));

            foreach (KeyValuePair<int,Employee> emp in employees)
            {
                Console.WriteLine($"ID: {emp.Key}, Name: {emp.Value.Name}, Age: {emp.Value.Age}, Salary: {emp.Value.Salary}$");
            }


            Console.ReadLine();
        }



    }
}