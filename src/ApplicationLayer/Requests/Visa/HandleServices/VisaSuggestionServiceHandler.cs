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
    public class VisaSuggestionServiceHandler : IQueryHandler<VisaSuggestion, IVisa>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        private readonly IVisaFactory _visaFactory;
        public VisaSuggestionServiceHandler(IVisaIntegrationService visaInterationService,
            IVisaFactory visaFactory)
        {
            _visaInterationService = visaInterationService;
            _visaFactory = visaFactory;
        }

        public Task<IVisa> HandleAsync(VisaSuggestion query, CancellationToken cancellationToken = default)
        {
            var suggestion = _visaInterationService.GetSuggestion(query.destination, query.reason, query.countryOfOrgin);

            if (suggestion is null) 
            {
                throw new ArgumentNullException("There was no suggestion found");
            }

            return suggestion;
        }
    }
}
