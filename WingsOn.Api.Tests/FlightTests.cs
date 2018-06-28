using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.Internal;
using WingsOn.Api.Tests.Utils;
using WingsOn.Domain;
using WingsOn.Domain.Dto;
using WingsOn.Domain.Dto.Results;
using Xunit;

namespace WingsOn.Api.Tests
{
    public class FlightTests
    {
        [Fact]
        public async Task GetPassengersOfFlight()
        {
            var expectedPassengerNames = new List<string> {"Claire Stephens", "Kendall Velazquez", "Zenia Stout"};

            using (var server = new TestServer(new WebHostBuilder().UseStartup<Startup>()))
            {
                using (var client = server.CreateClient())
                {
                    var response = await client.GetAsync("api/flight/PZ696/passengers");
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.DeserializeFromJson<ServiceResult<List<PersonDto>>>();

                    Assert.NotNull(result);

                    var people = result.Payload;
                    Assert.NotNull(people);
                    Assert.Equal(3, people.Count);
                    foreach (var expectedPassengerName in expectedPassengerNames)
                        Assert.Contains(people, person => person.Name == expectedPassengerName);
                }
            }
        }
    }
}