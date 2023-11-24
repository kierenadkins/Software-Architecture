using DomainLayer.Contracts.Applications;
using DomainLayer.Objects.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Jwt
{
    public class JwtGeneration : IJwtGeneration
    {
        private readonly IConfiguration _configuration;

        public JwtGeneration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(IUser user)
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
              expires: DateTime.Now.AddMinutes(90),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
