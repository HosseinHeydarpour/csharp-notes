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
            // Given
            var flight = new Flight(seatCapicity: 3);

            flight.Book("Hossein@gmail.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);   
        }

        [Fact]
        public void Avoids_overbooking()
        {
            // Given
            var flight = new Flight(seatCapicity: 3);

            // When
            var error = flight.Book("hossein@g.com", 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }
    }

    
}
