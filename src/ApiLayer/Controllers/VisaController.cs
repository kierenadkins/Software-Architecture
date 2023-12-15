using ApiLayer.ExceptionHandling;
using ApplicationLayer.Commands.Application;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.DTO.Visa.Suggestions;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Visa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;
using System.Diagnostics;

namespace ApiLayer.Controllers
{
    [Route("/visa")]
    [ApiController]
    public class VisaController : ControllerBase
    {
        private readonly IQueryHandler<VisaSuggestion, VisaDto> _VisaSuggestion;
        private readonly IQueryHandler<GetCountriesVisas, CountryVisaDto> _CountryVisas;
        private readonly IQueryHandler<GetVisa, VisaDto> _GetVisa;

        private readonly IExceptionHandler _exceptionHandler;

        public VisaController(IQueryHandler<VisaSuggestion, VisaDto> visaSuggestion,
            IQueryHandler<GetCountriesVisas, CountryVisaDto> countryVisas,
            IQueryHandler<GetVisa, VisaDto> getVisa,
            IExceptionHandler exceptionHandler)
        {
            _VisaSuggestion = visaSuggestion;
            _CountryVisas = countryVisas;
            _GetVisa = getVisa;
            _exceptionHandler = exceptionHandler;
        }

        [Authorize(Roles = "VisaApplicant")]
        [HttpPost("suggestion")]
        public async Task<IActionResult> GetSuggestion([FromBody] VisaSuggestion command)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var suggestion = await _VisaSuggestion.HandleAsync(command);
                Console.WriteLine("\n Time Taken To Execute Suggestion " + stopwatch.Elapsed);
                return new OkObjectResult(suggestion);

            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }

        [HttpPost("FindAllForCountry")]
        public async Task<IActionResult> GetCountryVisas([FromBody] GetCountriesVisas command)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var visas = await _CountryVisas.HandleAsync(command);
                Console.WriteLine("\n Time Taken To Execute Getting Visas " + stopwatch.Elapsed);
                return new OkObjectResult(visas);

            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }

        [HttpPost("FindVisa")]
        public async Task<IActionResult> GetVisa([FromBody] GetVisa command)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var visas = await _GetVisa.HandleAsync(command);
                Console.WriteLine("\n Time Taken To Execute get visas " + stopwatch.Elapsed);
                return new OkObjectResult(visas);

            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }
    }
}
