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

namespace ApplicationLayer.Commands.Application
{
    public record ApplicationSubmission(
        [Required]
        string FirstName) : ICommand;
}
