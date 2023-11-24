using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Auth.PasswordSecurity
{
    public interface IPasswordProtectionService
    {
       bool CompareHashedPasswords(string userInputPassword,
       string existingHashedBase64StringPassword,
       string salt);

        (string, string) HashPassword(string password);
    }
}
