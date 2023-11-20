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
using Shared.Services.Queries.Abstract;
using DomainLayer.Objects.Applications;

namespace ApplicationLayer.Commands.Application
{
    public record ApplicationForVisa(
        [Required]
        string id) : IQuery<IApplication>;
}
