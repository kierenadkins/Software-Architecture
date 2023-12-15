using DomainLayer.Contracts.Applications;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Excepetions.Users;
using DomainLayer.Objects.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Services.Auth.PasswordSecurity;
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
    public class UserLoginService : IQueryHandler<UserLogin, string>
    {
        private readonly IUsersReadRepository _userRepository;
        private readonly IJwtGeneration _jwtGeneration;
        private readonly IPasswordProtectionService _passwordProtectionService;
        public UserLoginService(IJwtGeneration jwtGeneration,
            IUsersReadRepository userRepository,
            IPasswordProtectionService passwordProtectionService)
        {
            _jwtGeneration = jwtGeneration;
            _userRepository = userRepository;
            _passwordProtectionService = passwordProtectionService;
        }

        public async Task<string> HandleAsync(UserLogin request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetAsync(request.Email);

            if (user is null)
                throw new NoUserFoundException(request.Email);

            if (user.AccountActive is false)
                throw new UserAccountIsNoLongerActive(request.Email);

            if (_passwordProtectionService.CompareHashedPasswords(request.Password, user.Password.Value, user.Salt) is false)
                 throw new UserPasswordDoesNotMatchException();

            return _jwtGeneration.CreateToken(user);
        }
    }
}
