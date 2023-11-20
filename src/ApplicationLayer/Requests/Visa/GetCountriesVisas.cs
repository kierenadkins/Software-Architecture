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
    public record GetCountriesVisas(
        [Required(ErrorMessage = "Require Destination")]
        string destination,
        [Required(ErrorMessage = "Require Country Of Orgin")]
        string countryOfOrgin) : IQuery<CountryVisaDto>;
}
