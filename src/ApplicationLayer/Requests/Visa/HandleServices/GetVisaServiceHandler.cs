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
    public class VisaServiceHandler : IQueryHandler<GetVisa, VisaDto>
    {
        private readonly IVisaIntegrationService _visaInterationService;
        public VisaServiceHandler(IVisaIntegrationService visaInterationService)
        {
            _visaInterationService = visaInterationService;
        }

        public async Task<VisaDto> HandleAsync(GetVisa query, CancellationToken cancellationToken = default)
        {
            var visa = await _visaInterationService.GetVisa(query.id);
            
            if (visa is null) 
            {
                throw new CannotFindVisaException(query.id);
            }

            //more logic could occur here

            return visa.ToVisaDto();
        }
    }
}
