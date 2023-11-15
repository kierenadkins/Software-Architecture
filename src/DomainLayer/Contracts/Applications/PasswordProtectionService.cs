using DomainLayer.Contracts.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainLayer.Contracts.Applications
{
    public class PasswordProtectionService : IPasswordService
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

        public (string, string) ProtectPassword(string userPassword)
        {
            PasswordSecurity(userPassword);
            string randomlyGenerateSalt = GenerateSalt();
            byte[] hashedPassword = GetHash(userPassword, randomlyGenerateSalt);
            string hashedBase64Password = Convert.ToBase64String(hashedPassword);
            return (randomlyGenerateSalt, hashedBase64Password);
        }

        public bool CompareHashedPasswords(string userInputPassword,
            string existingHashedBase64StringPassword,
            string salt)
        {
            string usersInputtedHashedPassword = Convert.ToBase64String(GetHash(userInputPassword, salt));
            return existingHashedBase64StringPassword == usersInputtedHashedPassword;
        }
        public void PasswordSecurity(string password)
        {
            Regex PasswordRegex = new(
            "((?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\\W)\\w.{6,18}\\w)");
            if (!PasswordRegex.IsMatch(password))
            {
                throw new Exception("password does not match criteria");
            };
        }

    }
}
