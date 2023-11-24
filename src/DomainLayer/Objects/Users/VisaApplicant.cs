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
    public class VisaOfficer : IUser
    {
        internal VisaOfficer(UserId id,
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
    }
}
