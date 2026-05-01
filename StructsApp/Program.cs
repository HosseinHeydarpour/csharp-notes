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
        public double X { get;  }
        public double Y { get;  }

        
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



    internal class Program
    {


        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            p1.Display();

            Point p2 = new Point(20,30);
            p2.Display();


            double distance = p1.DistanceTo(p2);
            // This F2 = Floating 2 returns 2 points after the decimal point
            Console.WriteLine($"Distance between points: {distance:F2}");
            

            Console.ReadLine();
        }
    }
}
