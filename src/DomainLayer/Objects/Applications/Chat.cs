using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class Chat : IChat
    {
        //this wont really be used for the prototype as it requires communication between visa applicant and visa officer
        public Chat(){}

        public string Firstname { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }

    }
}
