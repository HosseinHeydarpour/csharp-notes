namespace StructsApp
{
    /*
        What are Structs?
        
        - Structs (short for "structures") in C# are value types used to encapsulate
          small groups of related variables.
        
        - Structs are typically used for small data structures that represent a single
          value and usually are not modified after creation.
        
        - They are suitable for simple data that logically belongs together.
        
        - If a design requires inheritance, polymorphism, or large and complex data
          structures, classes are usually more appropriate.
        
        - Structs and classes can appear similar in structure, but they behave
          differently because structs are value types while classes are reference types.
    */


    /*
        Key Differences: Structs and Classes
        
        Value Type:
        
        - Structs are value types in C#.
        
        - Value types store their data directly rather than storing a reference
          to the data.
        
        - They are typically allocated on the stack or stored inline within
          containing types.
        
        - Because of this, structs can be more efficient in terms of memory
          allocation and access speed.
        
        - Classes, on the other hand, are reference types.
        
        - Reference types are stored on the heap and variables hold references
          to the actual object rather than the object itself.
   */

    /*
        Key Differences: Structs and Classes
        
        No Inheritance:
        
        - Structs do not support inheritance.
        
        - A struct cannot inherit from another struct or class.
        
        - However, structs can implement interfaces.
        
        - This allows structs to follow contracts and provide specific behavior
          without participating in class-based inheritance hierarchies.
    */

    


    public struct Point
    {
        /*
            * It's a common practice to make struts immutable
            * by declaring all fields as readonly and providing only
            * get accessors for properties.
             * 
         */
        // Structs can have props
        public double X { get; set; }
        public double Y { get; set; }

        
        // Structs can have constructors
        // This is a custom cnstructor
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        public void Display()
        {
            Console.WriteLine($"Point is at: ({X},{Y})");
        }
    }

    public class PointClass
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointClass(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        public void Display()
        {
            Console.WriteLine($"Point is at: ({X},{Y})");
        }
    }



    internal class Program
    {


        static void Main(string[] args)
        {
            Point p1 = new Point(10,20);
            p1.Display();

            Point p2 = p1; // p2 is a copy of p1
            p2.Display();

            p2.X = 25; // Changes p2 | p1 remains the same

            Console.WriteLine("After changing p2.X to 25");
            p1.Display();
            p2.Display();

            Console.WriteLine("NOW COME THE CLASS OBJECTS");
            PointClass pC1 = new PointClass(1, 2);
            PointClass pC2 = pC1;  //pC2 is a reference to the same object as pC1

            pC1.Display(); 
            pC2.Display();

            pC2.X = 3; // CHANGES p1.X as well, since p1 and p2 refrence the same object

            Console.WriteLine("After changing pC2.X to 3");
            pC1.Display();
            pC2.Display();



            bool isEqual = pC1.Equals(pC2);
            Console.WriteLine("Is it equal? "+ isEqual);


            Console.ReadLine();
        }
    }
}
