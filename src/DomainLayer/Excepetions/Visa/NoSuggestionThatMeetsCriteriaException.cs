using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class NoSuggestionThatMeetsCriteriaException : Exception
    {
        public NoSuggestionThatMeetsCriteriaException(string destination, string reason) : base(
            $"Cannot find visa for {destination} that is for {reason} please try again later")
        {
        }
    }
}
