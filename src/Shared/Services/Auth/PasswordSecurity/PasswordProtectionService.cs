using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Shared.Services.Auth.Exceptions;

namespace Shared.Services.Auth.PasswordSecurity
{
    public class PasswordProtectionService : IPasswordProtectionService
    {
        private string GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return Convert.ToBase64String(salt);
        }

        private byte[] GetHash(string unProtectedPassword, string salt)
        {
            byte[] byteArray = Encoding.Unicode.GetBytes(string.Concat(salt, unProtectedPassword));
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(byteArray);
            return hash;
        }

        public bool CompareHashedPasswords(string userInputPassword,
            string existingHashedBase64StringPassword,
            string salt)
        {
            string usersInputtedHashedPassword = Convert.ToBase64String(GetHash(userInputPassword, salt));
            return existingHashedBase64StringPassword == usersInputtedHashedPassword;
        }
        private bool PasswordSecurity(string password)
        {
            Regex PasswordRegex = new(
            "((?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\\W)\\w.{6,18}\\w)");
            if (!PasswordRegex.IsMatch(password))
            {
                throw new PasswordIsNotSecureException();
            };
            return true;
        }

        public (string, string) HashPassword(string password)
        {
            PasswordSecurity(password);
            string randomlyGenerateSalt = GenerateSalt();
            byte[] hashedPassword = GetHash(password, randomlyGenerateSalt);
            string hashedBase64Password = Convert.ToBase64String(hashedPassword);
            return (hashedBase64Password, randomlyGenerateSalt);
        }
    }
}
