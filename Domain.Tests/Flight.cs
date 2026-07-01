namespace Domain.Tests
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }

        

        public Flight(int seatCapicity)
        {
            RemainingNumberOfSeats = seatCapicity;
        }

        public void Book(string v1, int v2)
        {
            RemainingNumberOfSeats -=   v2;
        }
    }
}
