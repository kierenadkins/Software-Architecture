using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Visa
{
        [ExcludeFromCodeCoverage]
        public record VisaPurpose
    {
            public string Value;
            public VisaPurpose(string purpose)
            {
                if (string.IsNullOrEmpty(purpose) || purpose.Length < 3)
                {
                   // throw new InvalidUserFirstNameException(firstName);
                }

                Value = purpose;
            }

            public static implicit operator VisaPurpose(string firstName)
            {
                return new VisaPurpose(firstName);
            }
        }
    }