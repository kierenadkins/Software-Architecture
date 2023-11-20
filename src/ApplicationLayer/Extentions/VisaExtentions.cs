using ApplicationLayer.DTO.Application;
using ApplicationLayer.DTO.Visa.Suggestions;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Visas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Extentions
{
    public static class VisaExtensions
    {
        public static VisaDto ToVisaDto(this IVisa visa)
        {
            return new VisaDto(visa.Id.Value,
                visa.Title.Value,
                new(visa.Information.Overview, visa.Information.ApplicationProccess, visa.Information.LengthOfStay),
                new(visa.ElgibilityRules.Eligibility, visa.ElgibilityRules.EligibleCountires),
                new(visa.DocumentationRequirements.Description),
                visa.Country.Value,
                visa.Type.Value,
                visa.Purpose.Value);
        }

        private static VisaSummaryDto ToVisaSummaryDto(this IVisa visa)
        {
            return new(visa.Id.Value, visa.Title.Value, visa.Country.Value, visa.Type.ToString(), visa.Purpose.Value);
        }
        public static CountryVisaDto ToCountryVisaDto(this List<IVisa> visas)
        {
            return new CountryVisaDto(visas.Select(x => ToVisaSummaryDto(x)).ToList());
        }
    }
}
