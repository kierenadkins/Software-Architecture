using ApplicationLayer.DTO.Visa.Suggestions;
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
    public class VisaSuggestionServiceHandler : IQueryHandler<VisaSuggestion, VisaDto>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        private readonly IVisaFactory _visaFactory;
        public VisaSuggestionServiceHandler(IVisaIntegrationService visaInterationService,
            IVisaFactory visaFactory)
        {
            _visaInterationService = visaInterationService;
            _visaFactory = visaFactory;
        }

        public async Task<VisaDto> HandleAsync(VisaSuggestion query, CancellationToken cancellationToken = default)
        {
            var suggestion = await _visaInterationService.GetSuggestion(query.destination, query.reason, query.countryOfOrgin);
            
            if (suggestion is null) 
            {
                throw new NoSuggestionThatMeetsCriteriaException(query.destination, query.reason);
            }

            //more logic could occur here

            return suggestion.ToVisaDto();
        }
    }
}
