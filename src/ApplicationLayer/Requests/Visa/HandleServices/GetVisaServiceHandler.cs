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
    public class VisaServiceHandler : IQueryHandler<GetVisa, IVisa>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        private readonly IVisaFactory _visaFactory;
        public VisaServiceHandler(IVisaIntegrationService visaInterationService,
            IVisaFactory visaFactory)
        {
            _visaInterationService = visaInterationService;
            _visaFactory = visaFactory;
        }

        public async Task<IVisa> HandleAsync(GetVisa query, CancellationToken cancellationToken = default)
        {
            var visa = await _visaInterationService.GetVisa(query.id);
            
            if (visa is null) 
            {
                throw new ArgumentNullException("There was no suggestion found");
            }

            return visa;
        }
    }
}
