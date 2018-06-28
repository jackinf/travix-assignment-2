using System.Collections.Generic;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Results;

namespace WingsOn.Domain.Services
{
    public interface IFlightsService
    {
        ServiceResult<List<PersonDto>> GetPassengers(string flightNumber);
    }
}