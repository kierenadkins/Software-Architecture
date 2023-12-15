using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class UserExistsException : Exception
    {
        public UserExistsException(string email) : base(
            $"User Already Exists With Email: {email}")
        {
        }
    }
}
