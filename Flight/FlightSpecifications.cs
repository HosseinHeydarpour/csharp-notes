using System;
using Xunit;
using FluentAssertions;
using Domain;

namespace FlightTest
{
    public class FlightSpecifications
    {
        [Fact]
        public void Booking_reduces_the_number_of_seats()
        {

            var flight = new Flight(seatCapicity: 3);

            flight.Book("Hossein@gmail.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);   
        }
    }

    
}
