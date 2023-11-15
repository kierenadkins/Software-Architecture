using DomainLayer.Enums.UserEnum;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.UserDocuments
{
    public class UserDocument : Item
    {
        public UserDocument(
            string id,
            string firstName,
            string lastName,
            string email,
            string password,
            string salt,
            bool accountActive,
            Roles role,
            DateOnly dob,
            string? branchId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Salt = salt;
            AccountActive = accountActive;
            Role = role;
            Dob = dob;
            BranchId = branchId;

        }
        public string PartitionKey => Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AccountActive { get; set; } = true;
        public string Salt { get; set; }
        public Roles Role { get; set; }
        public DateOnly Dob { get; set; }
        public string? BranchId { get; set; } = null; 
       
    }
}
