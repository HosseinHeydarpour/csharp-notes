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

    public delegate void TemperatureChangeHandler(string message);

    public class TempMonitor
    {
        public event TemperatureChangeHandler OnTemperatureChanged;

        private int _temp;

        public int Temp { get { return _temp;  } 
        set
            {
                _temp = value;
                if (_temp > 30)
                {
                    // RAISE THE EVENT  
                    RaiseTempChangedEvent("Temp is above threshold!");
                }
                if (_temp < 20)
                {
                    // RAISE THE EVENT  
                    RaiseTempChangedEvent("Turn on the heater!");
                }
            }
        
        
        }

        protected virtual void RaiseTempChangedEvent(string message)
        {
            OnTemperatureChanged?.Invoke(message);
        }
    }

    public class TempAlert
    {
        public void OnTempChanged(string message)
        {
            Console.WriteLine("ALERT: " + message);
        }

    }
    internal class Program
    {



        static void Main(string[] args)
        {
            TempMonitor tempMonitor = new TempMonitor();
            TempAlert alert = new TempAlert();
            tempMonitor.OnTemperatureChanged += alert.OnTempChanged;

            tempMonitor.Temp = 20;

            Console.WriteLine("Please enter current degree: ");
            
            try
            {
                string? input = Console.ReadLine();
                if(input == null) throw new Exception("Input cannot be null");

                tempMonitor.Temp = int.Parse(input);

            } catch (FormatException ex)
            {
                Console.WriteLine("Input must be an integer");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


           





            Console.ReadKey();
        }


     
   

    }
}
