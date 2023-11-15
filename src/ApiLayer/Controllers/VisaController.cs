using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Visas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;

namespace ApiLayer.Controllers
{
    [Route("/visa")]
    [ApiController]
    public class VisaController : ControllerBase
    {
        private readonly IQueryHandler<VisaSuggestion, IVisa> _VisaSuggestion;

        public VisaController(IQueryHandler<VisaSuggestion, IVisa> visaSuggestion)
        {
            _VisaSuggestion = visaSuggestion;
        }

        [HttpPost("suggestion")]
        public async Task<IActionResult> GetSuggestion([FromBody] VisaSuggestion command)
        {
            try
            {

                var suggestion = await _VisaSuggestion.HandleAsync(command);
                return new OkObjectResult(suggestion);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }
    }
}
