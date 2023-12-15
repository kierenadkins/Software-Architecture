using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException(string email) : base(
            $"No User Found With Email: {email}")
        {
        }
    }
}
