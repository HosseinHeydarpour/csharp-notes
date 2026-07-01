namespace Domain
{

 

    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }
        public List<Booking> BookingsList { get; set; } = new List<Booking>();


        public Flight(int seatCapicity)
        {
            RemainingNumberOfSeats = seatCapicity;
        }


        public object? Book(string passengerEmail, int numberOfSeats)
        {

            if (numberOfSeats > this.RemainingNumberOfSeats)
            {
                return new OverbookingError();
            }

            RemainingNumberOfSeats -= numberOfSeats;

            BookingsList.Add(new Booking(passengerEmail, numberOfSeats));

            return null;

        }
    }
}
