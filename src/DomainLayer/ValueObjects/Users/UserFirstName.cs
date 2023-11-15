using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{

        [ExcludeFromCodeCoverage]
        public record UserFirstName
        {
            public string Value;
            public UserFirstName(string firstName)
            {
                if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                {
                   // throw new InvalidUserFirstNameException(firstName);
                }

                Value = firstName;
            }

            public static implicit operator UserFirstName(string firstName)
            {
                return new UserFirstName(firstName);
            }
        }
    }