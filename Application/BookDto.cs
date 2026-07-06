using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    // For transfering data
    public class BookDto
    {

        public Guid FlightId { get; set; }
        public string PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }

        public BookDto(Guid flighId, string passengerEmail, int numberOfSeats)
        {
            FlightId = flighId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }

}
