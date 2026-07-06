using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application;

namespace Applictaion
{
    public class FlighApplicationSpecification
    {

        readonly Entities entities = new Entities
            (
                new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options
            );

        readonly BookingService bookingService;

        public FlighApplicationSpecification()
        {
            bookingService =  new BookingService(entities: entities);
        }



        [Theory]
        [InlineData("m@m.com",2)]
        [InlineData("a@m.com", 3)]
     
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {


        
            var flight = new Flight(3);

            entities.Flights.Add(flight);

          

            bookingService.Book(new BookDto(
                flighId: flight.Id,
              passengerEmail,
                numberOfSeats: numberOfSeats
             ));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: passengerEmail, numberOfSeats: numberOfSeats)
                );


        }



        [Fact]
        public void Cancels_booking()
        {
            // Given
            
           
            var flight = new Flight(3);
            entities.Flights.Add(flight);

            
            bookingService.Book(
                new BookDto
                (
                flighId: flight.Id,
                passengerEmail: "m@m.com",
                2
                ));

            // When
            bookingService.CancelBooking
                (
                    new CancelBookingDto(
                        flightId: flight.Id,
                        passengerEmail: "m@m.com",
                        numberOfSeats: 2
                        )

                );


            // Then

            bookingService.GetRemainingNumberOfSeatsFor(flight.Id).Should().Be(3);

        }
            
    
    }



    


}
