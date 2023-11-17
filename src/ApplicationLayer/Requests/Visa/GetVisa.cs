using Shared.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Objects.Visas;

namespace ApplicationLayer.Requests.Users
{
    public record GetVisa(
        [Required(ErrorMessage = "Requires id")]
        string id) : IQuery<IVisa>;
}
