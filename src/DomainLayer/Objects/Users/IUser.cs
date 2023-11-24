using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Users
{
    public interface IUser
    {
        UserId Id { get; }
        UserFirstName FirstName { get; init; }
        UserLastName LastName { get; init; }
        UserEmail Email { get; }
        UserPassword Password { get; }
        string Salt { get; }
        DateOnly Dob { get; init; }
        bool AccountActive { get; }
        Roles UserLevel { get; init; }

        BranchId? BranchId { get; init; }
    }
}
