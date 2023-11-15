using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts.Applications
{
    public interface IPasswordService
    {
        bool CompareHashedPasswords(string userInputPassword,
        string existingHashedBase64StringPassword,
        string salt);

        (string, string) ProtectPassword(string userPassword);

        void PasswordSecurity(string password);
    }
}
