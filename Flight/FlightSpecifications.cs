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


        // DRY principle is not important here
        [Fact]
        public void Booking_reduces_the_number_of_seats_2()
        {
            // Given
            var flight = new Flight(seatCapicity: 6);

            flight.Book("Hossein@gmail.com", 3);

            flight.RemainingNumberOfSeats.Should().Be(3);
        }

        // DRY principle is not important here
        [Fact]
        public void Booking_reduces_the_number_of_seats_3()
        {
            // Given
            var flight = new Flight(seatCapicity: 10);

            flight.Book("Hossein@gmail.com", 3);

            flight.RemainingNumberOfSeats.Should().Be(7);
        }


        [Fact]
        public void Booking_reduces_the_number_of_seats_4()
        {
            // Given
            var flight = new Flight(seatCapicity: 10897);

            flight.Book("Hossein@gmail.com", 3);

            flight.RemainingNumberOfSeats.Should().Be(10897-3);
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


        [Fact]
        public void Books_flight_successfully()
        {
            // Given
            var flight = new Flight(seatCapicity:3);

            // When
            var error = flight.Book("A@g.com", 1);

            // Then
            error.Should().BeNull();

        }

    }

    
}
