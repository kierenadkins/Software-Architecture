using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Objects.Users;
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
    public class UserLoginService : IQueryHandler<UserLogin, string>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserLoginService(IConfiguration configuration,
            IUsersRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<string> HandleAsync(UserLogin request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetAsync(request.Email);

            if (user is null)
                throw new NotImplementedException();

            if (user.AccountActive is false)
                throw new NotImplementedException();

            if (user.DoesPasswordMatch(request.Password) is false)
                throw new NotImplementedException();

            return CreateToken(user);
        }

        private string CreateToken(IUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user.Id.Value.ToString()),
                new Claim("FirstName", user.FirstName.Value),
                new Claim("LastName", user.LastName.Value),
                new Claim("Email", user.Email.Value),
                new Claim(ClaimTypes.Role, user.UserLevel.ToString()),
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
