using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{
    [ExcludeFromCodeCoverage]
    public record UserLastName
    {
        public string Value;
        public UserLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
            {
                //throw new InvalidUserLastNameException(lastName);
            }

            Value = lastName;
        }

        public static implicit operator UserLastName(string LastName)
        {
            return new UserLastName(LastName);
        }
    }
}
