namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }

        

        public Flight(int seatCapicity)
        {
            RemainingNumberOfSeats = seatCapicity;
        }


        // wrong implementetion of booking

        //public object? Book(string passengerEmail, int numberOfSeats)
        //{

        //    //if(numberOfSeats > this.RemainingNumberOfSeats) 
        //    //{
        //    //    return new OverbookingError();
        //    //}

        //    RemainingNumberOfSeats -= numberOfSeats;
        //    //return null;

        //    return new OverbookingError();

            
        //}


        public object? Book(string passengerEmail, int numberOfSeats)
        {

            if (numberOfSeats > this.RemainingNumberOfSeats)
            {
                return new OverbookingError();
            }

            RemainingNumberOfSeats -= numberOfSeats;
            return null;

           


        }



    }
}
