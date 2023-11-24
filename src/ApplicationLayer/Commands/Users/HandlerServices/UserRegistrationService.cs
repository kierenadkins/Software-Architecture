using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Users;
using Shared.Services.Auth.PasswordSecurity;
using Shared.Services.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Users.HandlerServices
{
    public class UserRegistrationService : ICommandHandler<UserRegistration>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUsersRepository _userRepository;
        private readonly IPasswordProtectionService _passwordProtectionService;
        public UserRegistrationService(IUserFactory userFactory,
            IUsersRepository userRepository,
            IPasswordProtectionService passwordProtectionService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _passwordProtectionService = passwordProtectionService;
        }
        public async Task HandleAsync(UserRegistration command, CancellationToken cancellationToken = default)
        {
            var (firstName, lastName, email, password, dob, userType, branchid) = command;
            
            if(await _userRepository.ExistsAsync(email))
            {
                throw new NotImplementedException("User already exists");
            }

            var (passwordEncrypted, salt) = _passwordProtectionService.HashPassword(password);

            IUser user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        passwordEncrypted,
                        salt,
                        true,
                        dob,
                        userType,
                        branchid);

            await _userRepository.AddAsync(user);
        }
    }
}
