using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class CannotFindCountryVisasException : Exception
    {
        public CannotFindCountryVisasException(string country) : base(
            $"Cannot find visas for {country} please try again later")
        {
        }
    }
}
