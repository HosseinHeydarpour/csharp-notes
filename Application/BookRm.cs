using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{

    // For reading data
    public class BookingRm
    {

        public string PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }


        public BookingRm(string passengerEmail, int numberOfSeats)
        {
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
