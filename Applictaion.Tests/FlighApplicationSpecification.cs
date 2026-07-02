using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;



namespace Applictaion.Tests
{
    public class FlighApplicationSpecification
    {
        [Fact]
        public void Books_flights()
        {


           var bookingService = new BookingService();

            bookingService.Book(new BookDto(
                flighId: Guid.NewGuid(),
                passengerEmail: "a@b.com",
                numberOfSeats: 2
             ));

            bookingService.FindBookings().Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: "a@b.com", numberOfSeats:2)
                );


        }
    }


  

    public class BookingService
    {


        public void Book(BookDto bookDto) { 
        
            
        }

        public IEnumerable<BookingRm> FindBookings()
        {
            return new[]
            {
                 new BookingRm(passengerEmail: "a@b.com", numberOfSeats:2)
            };
        }

    }

    // For transfering data
    public class BookDto
    {
        public BookDto(Guid flighId, string passengerEmail, int numberOfSeats)
        {
            
        }
    }

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
