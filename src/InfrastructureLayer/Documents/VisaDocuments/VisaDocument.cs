using DomainLayer.ValueObjects.Visa;
using Microsoft.Azure.CosmosRepository;

namespace DomainLayer.Objects.Visas
{
    public class VisaDocument : Item
    {
        public VisaDocument(
            string id,
            string title,
            VisaInformationDocument information,
            VisaEligibilityRulesDocument elgibilityRules,
            VisaDocumentationRequirementsDocument documentationRequirements,
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
            VisaType = type;
            Purpose = purpose;
        }

        public string PartitionKey => Id;
        public string Title { get; init; }
        public VisaInformationDocument Information { get; init; }
        public VisaEligibilityRulesDocument ElgibilityRules { get; init; }
        public VisaDocumentationRequirementsDocument DocumentationRequirements { get; init; }
        public string Country { get; init; }
        public string VisaType { get; init; }
        public string Purpose { get; init; }
    }
}