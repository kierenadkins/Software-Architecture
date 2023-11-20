using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class Documentation : IDocumentation
    {
        public Documentation(List<string> requiredDocs) 
        {
            RequiredDocs = requiredDocs;
        }


        public List<DocumentationData> DocumentationData { get; set; } = new List<DocumentationData>();
        public List<string> RequiredDocs { get; set; } = new List<string>();
    }
}
