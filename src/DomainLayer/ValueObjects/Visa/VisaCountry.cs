using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Visa
{
        [ExcludeFromCodeCoverage]
        public record VisaCountry
        {
            public string Value;
            public VisaCountry(string country)
            {
                if (string.IsNullOrEmpty(country))
                {
                   // throw new InvalidUserFirstNameException(firstName);
                }

                Value = country;
            }

            public static implicit operator VisaCountry(string country)
            {
                return new VisaCountry(country);
            }
        }
    }