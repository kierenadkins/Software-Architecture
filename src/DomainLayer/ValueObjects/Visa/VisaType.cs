using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Visa
{
        [ExcludeFromCodeCoverage]
        public record VisaType //There is to many visas in the world to enum it
        {
            public string Value;
            public VisaType(string type)
            {
                if (string.IsNullOrEmpty(type))
                {
                   // throw new InvalidUserFirstNameException(firstName);
                }

                Value = type;
            }

            public static implicit operator VisaType(string type)
            {
                return new VisaType(type);
            }
        }
    }