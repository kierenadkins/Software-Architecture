using ApplicationLayer.Extentions;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Excepetions.Users;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Requests.Users.HandleServices
{
    public class CountriesVisasServiceHandler : IQueryHandler<GetCountriesVisas, CountryVisaDto>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        public CountriesVisasServiceHandler(IVisaIntegrationService visaInterationService)
        {
            _visaInterationService = visaInterationService;
        }

        public async Task<CountryVisaDto> HandleAsync(GetCountriesVisas query, CancellationToken cancellationToken = default)
        {
            var visas = await _visaInterationService.FindCountriesVisas(query.destination, query.countryOfOrgin);

            if (visas is null)
            {
               throw new CannotFindCountryVisasException(query.destination); ;
            }

            //more logic could occur here

            return visas.ToCountryVisaDto();
        }
    }
}
