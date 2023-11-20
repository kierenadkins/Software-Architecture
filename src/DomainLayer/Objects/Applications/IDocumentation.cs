
namespace DomainLayer.Objects.Applications
{
    public interface IDocumentation
    {
        List<string> RequiredDocs { get; set; } 
        List<DocumentationData> DocumentationData { get; set; }
    }
}