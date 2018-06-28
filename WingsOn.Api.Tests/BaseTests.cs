using System.Globalization;
using WingsOn.Domain;
using WingsOn.Domain.Dto;

namespace WingsOn.Api.Tests
{
    public abstract class BaseTests
    {
        protected readonly CultureInfo CultureInfo = new CultureInfo("nl-NL");

        static BaseTests()
        {
            AutoMapper.Mapper.Initialize(config => { config.CreateMap<Person, PersonDto>().ReverseMap();});
        }
    }
}