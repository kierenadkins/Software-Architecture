namespace ApplicationLayer.DTO.Visa.Suggestions
{
    public class VisaDocumentationRequirementsDto
    {
        public VisaDocumentationRequirementsDto(string description)
        {
            Description = description;
        }

        public string Description { get; init; }
    }
}