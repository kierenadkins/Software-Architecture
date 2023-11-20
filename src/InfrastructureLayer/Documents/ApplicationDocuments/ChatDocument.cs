using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class ChatDocument
    {
        //this wont really be used for the prototype as it requires communication between visa applicant and visa officer
        public ChatDocument(string firstname, string time, string message)
        {
            Firstname = firstname;
            Time = time;
            Message = message;
        }

        public string Firstname { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }

    }
}
