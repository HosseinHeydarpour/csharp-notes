namespace EventsAndDelegatesApp
{


    // Events in C#?

    // What is an Event?
    // An event lets one class tell others when something important happens.
    // It uses a special method called a delegate.
    // This means one part of the program can alert others
    // without needing direct connections.

    // Why use an Event?
    // Events allow a class to send updates without knowing who gets them.
    // This makes the system more flexible and organized.
    // It helps different parts of the program work together
    // without being tightly connected.

    // When would we use and Event?
    //
    // Use events when one object needs to inform others about changes or actions.
    // It's useful for keeping things updated without direct connections.
    // This can be important in many scenarios where multiple parts need to stay in sync
    // 

    // Where would we use an event?
    // Events are common in logging, monitoring, data changes, and button clicks. They are used whenever
    // notifications are needed.
    // Any situation where one action triggers other responses can benefit from events.

    public delegate void Notify(string message); 
       

    public class EventPublisher
    {
        // This OnNotify "On" is really important because it shows we are talking about an event
        // The "On" prefix make it immediately clear that the method
        // is associated with an event.
        // It signifies that the method is not just a regular method but
        // one that is called when a specific event occurs
        public event Notify OnNotify;

        public void RaiseEvent(string meesage)
        {
            OnNotify?.Invoke(meesage); // Invoke event if they are any subscribers thats why we use "?"
        }
    }

    public class EventSubscriber
    {
        public void OnEventRaised(string meesage)
        {
            Console.WriteLine("Event happened " + meesage);
            //Console.WriteLine(2*2);
        }
    }
    

    internal class Program
    {



        static void Main(string[] args)
        {

          


            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            publisher.OnNotify += subscriber.OnEventRaised;
            publisher.OnNotify += subscriber.OnEventRaised;
            publisher.RaiseEvent("Test");


            Console.ReadKey();
        }


     
   

    }
}
