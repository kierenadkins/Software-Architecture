using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Auth.Exceptions
{
    public class PasswordIsNotSecureException : Exception
    {
        public PasswordIsNotSecureException() : base(
            $"Password needs to be more secure, 8 characters and a special character")
        {
        }
    }
}
