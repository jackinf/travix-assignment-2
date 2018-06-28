using System.Collections.Generic;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Requests;
using WingsOn.Domain.Dto.Results;

namespace WingsOn.Domain.Services
{
    public interface IPersonService
    {
        ServiceResult<PersonDto> GetSingle(int id);

        ServiceResult<List<PersonDto>> GetAllMale(PersonSearchRequestDto options);
    }
}