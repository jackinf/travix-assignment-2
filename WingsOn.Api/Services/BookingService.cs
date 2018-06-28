using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Results;
using WingsOn.Domain.Exceptions;
using WingsOn.Domain.Factories;
using WingsOn.Domain.Repository;
using WingsOn.Domain.Services;
using WingsOn.Domain.Utils;

namespace WingsOn.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) 
            => _bookingRepository = bookingRepository;

        public ServiceResult<List<PersonDto>> GetPassengers(string flightNumber)
        {
            flightNumber.ArgumentNotNullOrWhitespace(nameof(flightNumber), "Flight number was not supplied. Please supply flight number.");

            var booking = _bookingRepository.GetByFlightNumber(flightNumber);
            if (booking == null)
                throw new ItemNotFoundException($"Booking with flight number {flightNumber} was not found.");

            var passengers = booking.Passengers;
            var dtos = passengers?.Select(Mapper.Map<PersonDto>).ToList() ?? new List<PersonDto>();

            return ServiceResultFactory.Success(dtos);
        }
    }
}