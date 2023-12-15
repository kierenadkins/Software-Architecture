using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class UnsecurePasswordException : Exception
    {
        public UnsecurePasswordException() : base(
            $"Password is not secure enough, 8 characters and one special character")
        {
        }
    }
}
