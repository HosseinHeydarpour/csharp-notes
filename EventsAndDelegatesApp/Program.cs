namespace EventsAndDelegatesApp
{


    // Using the Generic Delegate EventHandler<TEventArgs>

    // public delegate void TemperatureChangeHandler(string message);

    public class TempChangedEventArgs : EventArgs
    {
        // Property holding the temperature
        public int Temperature { get; }


        // Constructur
        public TempChangedEventArgs(int temperature) 
        {
            Temperature = temperature;
        }


    }

    public class TempMonitor
    {

        public event EventHandler<TempChangedEventArgs> TemperatureChanged;
        // public event TemperatureChangeHandler OnTemperatureChanged;

        private int _temp;

        public int Temp { get { return _temp;  } 
        set
            {
                
                if(_temp != value)
                {
                    _temp = value;
                    // Raise event
                    OnTempChanged(new TempChangedEventArgs(value));
                }
            }
        
        
        }

        protected virtual void OnTempChanged(TempChangedEventArgs e)
        {
            // Letting every subsciber know!
            TemperatureChanged?.Invoke(this,e);
        }
    }

    // Subscriber 
    public class TempAlert
    {
        public void OnTempChanged(object sender, TempChangedEventArgs e)
        {
            Console.WriteLine($"ALERT: tempetature is {e.Temperature} sender is: {sender}" );
        }

    }

    public class TempCoolingAlert
    {
        public void OnTempChanged(object sender, TempChangedEventArgs e)
        {
            Console.WriteLine($"Temp Cooling Alert: tempetature is {e.Temperature} sender is: {sender}");
        }

    }



    internal class Program
    {



        static void Main(string[] args)
        {
            TempMonitor tempMonitor = new TempMonitor();
            TempAlert alert = new TempAlert();
            TempCoolingAlert alert2 = new TempCoolingAlert();
            tempMonitor.TemperatureChanged += alert.OnTempChanged;
            tempMonitor.TemperatureChanged += alert2.OnTempChanged;

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
