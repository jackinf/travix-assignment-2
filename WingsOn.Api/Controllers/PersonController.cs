using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingsOn.Domain.Dto.Requests;
using WingsOn.Domain.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/person")]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService) : base(logger) 
            => _personService = personService;

        [Route("{id:number}")]
        [HttpGet]
        public IActionResult Get(int id) => HandleResult(() 
            => _personService.GetSingle(id));

        [Route("male-only")]
        [HttpGet]
        public IActionResult GetAllMale([FromQuery] PersonSearchRequestDto options) 
            => HandleResult(() => _personService.GetAllMale(options));
    }
}