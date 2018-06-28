using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingsOn.Domain.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/booking")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService) : base(logger)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Get(string flightNumber) => HandleResult(()
            => _bookingService.GetPassengers(flightNumber));
    }
}