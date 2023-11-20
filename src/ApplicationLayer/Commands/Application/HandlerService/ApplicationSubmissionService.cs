using ApplicationLayer.Commands.Application;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Factory.ApplicationFactory;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Users;
using Shared.Services.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Users.HandlerServices
{
    public class ApplicationSubmissionService : ICommandHandler<ApplicationSubmission>
    {
        private readonly IApplicationFactory _userFactory;
        private readonly IVisaIntegrationService _userRepository;
        public ApplicationSubmissionService(IApplicationFactory userFactory,
            IVisaIntegrationService userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(ApplicationSubmission command, CancellationToken cancellationToken = default)
        {
            
        }
    }
}
