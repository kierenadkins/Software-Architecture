using ApplicationLayer.Commands.Application;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;

namespace Api.Controllers
{
    [Route("/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IQueryHandler<ApplicationForVisa, IApplication?> _applicationForVisa;

        public ApplicationController(IQueryHandler<ApplicationForVisa, IApplication?> applicationForVisa)
        {
            _applicationForVisa = applicationForVisa;
        }

        [HttpPost("StartApplication")]
        public async Task<IActionResult> StartApplication([FromBody] ApplicationForVisa query)
        {
            try
            {
                var result = await _applicationForVisa.HandleAsync(query);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }

    }
}