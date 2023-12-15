using DomainLayer.Excepetions.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{
    [ExcludeFromCodeCoverage]
    public record UserPassword
    {
        public string Value;

        public UserPassword(string password)
        {
            if (password.Length < 6)
            {
                throw new UnsecurePasswordException();
            }

            Value = password;
        }

        public static implicit operator UserPassword(string password)
        {
            return new UserPassword(password);
        }
    }
}
