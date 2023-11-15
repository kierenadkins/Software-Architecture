using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Objects.Visas
{
    public class Visa : IVisa
    {
        internal Visa(
            VisaId id, 
            VisaTitle title,
            VisaInformation information,
            VisaEligibilityRules elgibilityRules,
            VisaDocumentationRequirements documentationRequirements,
            VisaCountry country, 
            VisaType type,
            VisaPurpose purpose)
        {
            Id = id;
            Title = title;
            Information = information;
            ElgibilityRules= elgibilityRules;
            DocumentationRequirements= documentationRequirements;
            Country = country;
            Type = type;
            Purpose = purpose;
        }

        public VisaId Id { get; init; }
        public VisaTitle Title { get; init; }
        public VisaInformation Information { get; init; }
        public VisaEligibilityRules ElgibilityRules { get; init; }
        public VisaDocumentationRequirements DocumentationRequirements {get; init; }
        public VisaCountry Country { get; init; }
        public VisaType Type { get; init; }
        public VisaPurpose Purpose { get; init; }
      
    }
}