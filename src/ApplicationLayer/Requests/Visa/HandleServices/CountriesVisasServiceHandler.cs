using DomainLayer.Contracts.Infrastructure;
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
    public class CountriesVisasServiceHandler : IQueryHandler<GetCountriesVisas, ICountryVisas>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        private readonly ICountryVisaFactory _countiresVisaFactory;
        public CountriesVisasServiceHandler(IVisaIntegrationService visaInterationService,
            ICountryVisaFactory countiresVisaFactory)
        {
            _visaInterationService = visaInterationService;
            _countiresVisaFactory = countiresVisaFactory;
        }

        public async Task<ICountryVisas> HandleAsync(GetCountriesVisas query, CancellationToken cancellationToken = default)
        {
            var visas = await _visaInterationService.FindCountriesVisas(query.destination, query.countryOfOrgin);

            if (visas is null)
            {
                throw new ArgumentNullException("There was no suggestion found");
            }

            var countryVisas = _countiresVisaFactory.CreateCountryVisa(visas);

            return countryVisas;
        }
    }
}
