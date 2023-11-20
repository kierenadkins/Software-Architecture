using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class DocumentationDocument
    {
        public DocumentationDocument() { }

        public List<string> RequiredDocs { get; set; } = new List<string>();
        public List<DocumentationDataDocument> DocumentationData { get; set; } = new List<DocumentationDataDocument>();
    }
}
