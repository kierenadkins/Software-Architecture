using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{
    [ExcludeFromCodeCoverage]
    public record UserEmail
    {
        public string Value;
        public static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        public UserEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                //throw new InvalidUserEmailException();
            }

            Value = email;
        }

        public static implicit operator UserEmail(string email)
        {
            return new UserEmail(email);
        }
    }
}
