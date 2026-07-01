using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{

    public interface IBooking
    {
        string PassengerEmail { get; set; }
        int NumberOfSeats { get; set; }
    }

    public class Booking : IBooking
    {
        public string PassengerEmail { get; set;}
        public int NumberOfSeats { get; set; }

        public Booking(string passengerEmail, int numberOfSeats)
        {
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
