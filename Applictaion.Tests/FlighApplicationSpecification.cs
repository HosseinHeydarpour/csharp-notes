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
        [Theory]
        [InlineData("m@m.com",2)]
        [InlineData("a@m.com", 3)]
     
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {


            var entities = new Entities
            (
                new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options
            );
            var flight = new Flight(3);

            entities.Flights.Add(flight);

           var bookingService = new BookingService(entities: entities);


            bookingService.Book(new BookDto(
                flighId: flight.Id,
              passengerEmail,
                numberOfSeats: numberOfSeats
             ));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: passengerEmail, numberOfSeats: numberOfSeats)
                );


        }
    }


}
