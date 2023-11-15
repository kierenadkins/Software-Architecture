using Shared.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Requests.Users
{
    public record UserLogin(
        [Required] [EmailAddress]
        string Email,
        [Required][PasswordPropertyText]
        string Password) : IQuery<string>;
}
