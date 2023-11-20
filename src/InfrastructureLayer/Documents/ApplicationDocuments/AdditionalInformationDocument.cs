using DomainLayer.Objects.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class AdditionalInformationDocument
    {
        //this wont really be used for the prototype as it requires communication between visa applicant and visa officer
        public AdditionalInformationDocument()
        {
        }

        public List<ChatDocument> chat = new List<ChatDocument>();

      
    }
}
