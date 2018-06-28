using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingsOn.Domain.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/flight")]
    public class FlightController : BaseController
    {
        private readonly IFlightsService _flightsService;

        public FlightController(ILogger<FlightController> logger, IFlightsService flightsService) : base(logger) 
            => _flightsService = flightsService;

        [HttpGet]
        [Route("{flightNumber}/passengers")]
        public IActionResult GetPassengers([FromRoute] string flightNumber) 
            => HandleResult(() => _flightsService.GetPassengers(flightNumber));
    }
}