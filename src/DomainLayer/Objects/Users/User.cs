using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Users
{
    public class User : IUser
    {
        internal User(UserId id,
            UserFirstName firstName,
            UserLastName lastName,
            UserEmail email,
            UserPassword password,
            DateOnly dob,
            Roles role,
            BranchId? branchId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Dob = dob;
            UserLevel = role;
            BranchId = branchId;
        }

        internal User(UserId id,
            UserFirstName firstName,
            UserLastName lastName,
            UserEmail email,
            UserPassword password,
            string salt,
            bool accountActive,
            DateOnly dob,
            Roles role,
            BranchId? branchId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Salt = salt;
            AccountActive = accountActive;
            Dob = dob;
            UserLevel = role;
            BranchId = branchId;
        }

        public UserId Id { get; private set; }
        public UserFirstName FirstName { get; init; }
        public UserLastName LastName { get; init; }
        public UserEmail Email { get; private set; }
        public UserPassword Password { get; private set; }
        public string Salt { get; private set; }
        public bool AccountActive { get; private set; } = true;
        public Roles UserLevel { get; init; }
        public DateOnly Dob { get; init; }

        public BranchId? BranchId { get; init; }

        public bool DoesPasswordMatch(string enteredPassword)
        {
            return CompareHashedPasswords(enteredPassword, Password.Value, Salt);

        }

        public void EncryptPassword() 
        {
            ProtectPassword();
        }

        public bool IsAdmin() => UserLevel == Roles.Admin;

        public bool IsBranchManager() => UserLevel == Roles.BranchManager;

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

        private void ProtectPassword()
        {
            var password = Password.Value;
            PasswordSecurity(password);
            string randomlyGenerateSalt = GenerateSalt();
            byte[] hashedPassword = GetHash(password, randomlyGenerateSalt);
            string hashedBase64Password = Convert.ToBase64String(hashedPassword);
            Salt = randomlyGenerateSalt;
            Password = hashedBase64Password;
        }

        private bool CompareHashedPasswords(string userInputPassword,
            string existingHashedBase64StringPassword,
            string salt)
        {
            string usersInputtedHashedPassword = Convert.ToBase64String(GetHash(userInputPassword, salt));
            return existingHashedBase64StringPassword == usersInputtedHashedPassword;
        }
        private void PasswordSecurity(string password)
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
