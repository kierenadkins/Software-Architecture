﻿using ApplicationLayer.Commands.Application;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.DTO.Visa.Suggestions;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Applications;
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
        private readonly IQueryHandler<VisaSuggestion, VisaDto> _VisaSuggestion;
        private readonly IQueryHandler<GetCountriesVisas, CountryVisaDto> _CountryVisas;
        private readonly IQueryHandler<GetVisa, VisaDto> _GetVisa;

        public VisaController(IQueryHandler<VisaSuggestion, VisaDto> visaSuggestion,
            IQueryHandler<GetCountriesVisas, CountryVisaDto> countryVisas,
            IQueryHandler<GetVisa, VisaDto> getVisa)
        {
            _VisaSuggestion = visaSuggestion;
            _CountryVisas = countryVisas;
            _GetVisa = getVisa;
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

        [HttpPost("FindAllForCountry")]
        public async Task<IActionResult> GetCountryVisas([FromBody] GetCountriesVisas command)
        {
            try
            {

                var visas = await _CountryVisas.HandleAsync(command);
                return new OkObjectResult(visas);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }

        [HttpPost("FindVisa")]
        public async Task<IActionResult> GetVisa([FromBody] GetVisa command)
        {
            try
            {

                var visas = await _GetVisa.HandleAsync(command);
                return new OkObjectResult(visas);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }
    }
}
