namespace Domain
{

 

    public class Flight
    {
        // Make booking list private so we can only access it from the inside of the class
        List<Booking> bookingList = new();
        public IEnumerable<Booking> BookingList => bookingList;


        public int RemainingNumberOfSeats { get; set; }
        
        public Guid Id { get;  }

        [Obsolete("Neede By Ef")]
        public Flight()
        {
            

        }

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

            bookingList.Add(new Booking(passengerEmail, numberOfSeats));

            return null;

        }

        public object? CancelBooking(string passengerEmail, int numberOfSeats)
        {
            if (!bookingList.Any(booking => booking.PassengerEmail == passengerEmail))
                return new BookingNotFoundError();


            RemainingNumberOfSeats  += numberOfSeats;


            return null;
        }
    }
}
