using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Visas
{
    public interface IVisa
    {
        VisaId Id { get; init; }
        VisaTitle Title { get; init; }

        VisaInformation Information { get; init; }
        VisaEligibilityRules ElgibilityRules { get; init; }
        VisaDocumentationRequirements DocumentationRequirements { get; init; }
        VisaCountry Country { get; init; }
        VisaType Type { get; init; }
        VisaPurpose Purpose { get; init; }

    }
}
