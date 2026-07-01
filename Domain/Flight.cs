namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }

        

        public Flight(int seatCapicity)
        {
            RemainingNumberOfSeats = seatCapicity;
        }

        public void Book(string passengerEmail, int numberOfSeats)
        {
            RemainingNumberOfSeats -= numberOfSeats;
        }
    }
}
