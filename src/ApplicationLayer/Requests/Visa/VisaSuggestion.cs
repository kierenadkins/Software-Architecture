﻿using Shared.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Objects.Visas;
using ApplicationLayer.DTO.Visa.Suggestions;

namespace ApplicationLayer.Requests.Users
{
    public record VisaSuggestion(
        [Required(ErrorMessage = "Require Destination")]
        string destination,
        [Required(ErrorMessage = "Reason For Travel")]
        string reason,
        [Required(ErrorMessage = "Require Country Of Orgin")]
        string countryOfOrgin) : IQuery<VisaDto>;
}
