using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Visa
{
        [ExcludeFromCodeCoverage]
        public record VisaTitle
        {
            public string Value;
            public VisaTitle(string title)
            {
                if (string.IsNullOrEmpty(title))
                {
                   // throw new InvalidUserFirstNameException(firstName);
                }

                Value = title;
            }

            public static implicit operator VisaTitle(string title)
            {
                return new VisaTitle(title);
            }
        }
    }