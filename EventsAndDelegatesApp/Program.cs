namespace EventsAndDelegatesApp
{
    internal class Program
    {

        // 1. Declaration:
        // This says: "I can hold any method that returns void and takes a string."
        public delegate void Notify(string message);

        static void Main(string[] args)
        {
            // Delegates define a method signature
            // and any method assigned to a adelegate must match this signature.




            // 2. Instantiation: 
            Notify notifyDelegate = ShowMessage;

            // old school way 
            //Notify notifyDelegate = new Notify(ShowMessage);



            // 3. Invocation: 
            notifyDelegate("Hello, Delegates!");



            Console.ReadKey();
        }

        static void ShowMessage(string message) {
            Console.WriteLine(message);
        }
    }
}
