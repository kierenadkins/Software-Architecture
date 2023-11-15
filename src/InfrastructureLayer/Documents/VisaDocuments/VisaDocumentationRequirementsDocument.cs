namespace DomainLayer.Objects.Visas
{
    public class VisaDocumentationRequirementsDocument
    {
        public VisaDocumentationRequirementsDocument(string description)
        {
            Description = description;
        }

        public string Description { get; init; }
    }
}