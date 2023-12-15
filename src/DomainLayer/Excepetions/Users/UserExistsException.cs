using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class UserPasswordDoesNotMatchException : Exception
    {
        public UserPasswordDoesNotMatchException() : base(
            $"Password does not match the user account")
        {
        }
    }
}
