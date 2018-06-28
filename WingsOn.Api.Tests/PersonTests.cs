using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using WingsOn.Api.Tests.Utils;
using WingsOn.Domain;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Results;
using Xunit;

namespace WingsOn.Api.Tests
{
    public class PersonTests : BaseTests
    {
        [Fact]
        public async Task GetSpecific()
        {
            using (var server = new TestServer(new WebHostBuilder().UseStartup<Startup>()))
            {
                using (var client = server.CreateClient())
                {
                    var response = await client.GetAsync("api/person/91");
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.DeserializeFromJson<ServiceResult<PersonDto>>();

                    Assert.NotNull(result);

                    var person = result.Payload;
                    Assert.NotNull(person);
                    Assert.Equal("805-1408 Mi Rd.", person.Address);
                    Assert.Equal(DateTime.Parse("24/09/1980", CultureInfo), person.DateBirth);
                    Assert.Equal("egestas.a.dui@aliquet.ca", person.Email);
                    Assert.Equal(GenderType.Male, person.Gender);
                    Assert.Equal("Kendall Velazquez", person.Name);
                }
            }
        }

        [Fact]
        public async Task GetAllMale()
        {
            using (var server = new TestServer(new WebHostBuilder().UseStartup<Startup>()))
            {
                using (var client = server.CreateClient())
                {
                    var response = await client.GetAsync("api/person/male-only");
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.DeserializeFromJson<ServiceResult<List<PersonDto>>>();

                    Assert.NotNull(result);

                    var people = result.Payload;
                    Assert.True(people.Count > 0);
                    Assert.True(people.All(x => x.Gender == GenderType.Male));
                }
            }
        }
    }
}
