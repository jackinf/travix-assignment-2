using System.Collections.Generic;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Results;

namespace WingsOn.Domain.Services
{
    public interface IBookingService
    {
        ServiceResult<List<PersonDto>> GetPassengers(string flightNumber);
    }
}