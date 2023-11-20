using DomainLayer.ValueObjects.Visa;

namespace ApplicationLayer.DTO.Visa.Suggestions
{
    public class VisaDto
    {
        internal VisaDto(
            Guid id,
            string title,
            VisaInformationDto information,
            VisaEligibilityRulesDto elgibilityRules,
            VisaDocumentationRequirementsDto documentationRequirements,
            string country,
            string type,
            string purpose)
        {
            Id = id;
            Title = title;
            Information = information;
            ElgibilityRules = elgibilityRules;
            DocumentationRequirements = documentationRequirements;
            Country = country;
            Type = type;
            Purpose = purpose;
        }

        public Guid Id { get; init; }
        public string Title { get; init; }
        public VisaInformationDto Information { get; init; }
        public VisaEligibilityRulesDto ElgibilityRules { get; init; }
        public VisaDocumentationRequirementsDto DocumentationRequirements { get; init; }
        public string Country { get; init; }
        public string Type { get; init; }
        public string Purpose { get; init; }

    }
}