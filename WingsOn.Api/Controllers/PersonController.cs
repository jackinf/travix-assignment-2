using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingsOn.Domain.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/person")]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService) : base(logger) 
            => _personService = personService;

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id) => HandleResult(() 
            => _personService.GetSingle(id));

        [Route("male-only")]
        [HttpGet]
        public IActionResult GetAllMale() 
            => HandleResult(() => _personService.GetAllMale());
    }
}