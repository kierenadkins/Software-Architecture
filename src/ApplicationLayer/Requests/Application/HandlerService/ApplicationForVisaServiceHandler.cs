using ApplicationLayer.Commands.Application;
using ApplicationLayer.Requests.Users;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Factory.ApplicationFactory;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Users;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Users.HandlerServices
{
    public class ApplicationForVisaServiceHandler : IQueryHandler<ApplicationForVisa, IApplication>
    {
        private readonly IVisaIntegrationService _VisaIntegrationService;
        public ApplicationForVisaServiceHandler(
            IVisaIntegrationService visaIntegrationService)
        {
            _VisaIntegrationService = visaIntegrationService;
        }

        public Task<IApplication>? HandleAsync(ApplicationForVisa query, CancellationToken cancellationToken = default)
        {
            var x = _VisaIntegrationService.GetApplication(query.id);

            if(x is null)
            {
                return null;
            }

            return x;
        }
    }
}
