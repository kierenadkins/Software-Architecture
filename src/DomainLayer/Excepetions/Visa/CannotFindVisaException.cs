using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class CannotFindVisaException : Exception
    {
        public CannotFindVisaException(string id) : base(
            $"Cannot find visa with id {id}")
        {
        }
    }
}
