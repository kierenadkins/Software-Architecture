namespace DomainLayer.Objects.Visas
{
    public class VisaDocumentationRequirements : IVisaDocumentationRequirements
    {
        public VisaDocumentationRequirements(string description)
        {
            Description = description;
        }

        public string Description { get; init; }
    }
}