using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Services.Commands.Abstract;
using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Users;

namespace ApplicationLayer.Commands.Users
{
    public record UserRegistration(
        [Required]
        string FirstName,
        [Required]
        string LastName,
        [Required] [EmailAddress]
        string Email,
        [Required][PasswordPropertyText]
        string Password,
        [Required]
        DateOnly Dob,
        [Required]
        Roles UserType,
        string? Branchid = null) : ICommand;
}
