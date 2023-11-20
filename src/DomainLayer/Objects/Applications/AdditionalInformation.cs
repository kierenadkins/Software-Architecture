using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class AdditionalInformation : IAdditionalInformation
    {
        //this wont really be used for the prototype as it requires communication between visa applicant and visa officer
        public AdditionalInformation()
        {
        }

        public List<Chat> chat { get; set; } = new List<Chat>();

        public void addNewChat(string firstname, DateTime time, string message)
        {
            chat.Add(new Chat());
        }
    }
}
