using System.Collections.Generic;
using AutoMapper;
using WingsOn.Domain;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Requests;
using WingsOn.Domain.Dto.Results;
using WingsOn.Domain.Factories;
using WingsOn.Domain.Repository;
using WingsOn.Domain.Services;
using WingsOn.Domain.Utils;

namespace WingsOn.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ServiceResult<PersonDto> GetSingle(int personId)
        {
            personId.ArgumentNotLessThan(0, nameof(personId), "Person id was invalid. Please supply positive id.");

            var model = _personRepository.Get(personId);
            if (model == null)
                return ServiceResultFactory.Fail<PersonDto>("Person with Id {personId} was not found.");

            var dto = Mapper.Map<PersonDto>(model);
            return ServiceResultFactory.Success(dto);
        }

        public ServiceResult<List<PersonDto>> GetAllMale()
        {
            var results = _personRepository.Search(new PersonSearchRequestDto { Gender = GenderType.Male });
            var dtos = Mapper.Map<List<PersonDto>>(results);
            return ServiceResultFactory.Success(dtos);
        }
    }
}