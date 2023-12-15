using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Excepetions.Users
{
    public class UserAccountIsNoLongerActive : Exception
    {
        public UserAccountIsNoLongerActive(string email) : base(
            $"User with email: {email} is not active")
        {
        }
    }
}
