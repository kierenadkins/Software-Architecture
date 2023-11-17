using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Visa;
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
        private readonly IQueryHandler<GetCountriesVisas, ICountryVisas> _CountryVisas;

        public VisaController(IQueryHandler<VisaSuggestion, IVisa> visaSuggestion, IQueryHandler<GetCountriesVisas, ICountryVisas> countryVisas)
        {
            _VisaSuggestion = visaSuggestion;
            _CountryVisas = countryVisas;
        }

        [Authorize(Roles = "VisaApplicant")]
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

        [HttpPost("Country/Visas")]
        public async Task<IActionResult> GetCountryVisas([FromBody] GetCountriesVisas command)
        {
            try
            {

                var visas = await _CountryVisas.HandleAsync(command);
                return new OkObjectResult(visas.GetVisa("Student"));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }
    }
}
