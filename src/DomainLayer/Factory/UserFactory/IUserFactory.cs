using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Users;
using DomainLayer.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Factory.UserFactory
{
    public interface IUserFactory
    {
        IUser CreateUserAccount(UserId id,
            UserFirstName firstName,
            UserLastName lastName,
            UserEmail email,
            UserPassword password,
            DateOnly dateOnly,
            Roles role,
            BranchId? branchId = null);

        IUser RetrieveUserAccount(
            UserId id,
            UserFirstName firstName,
            UserLastName lastName,
            UserEmail email,
            UserPassword password,
            string salt, 
            bool accountActive,
            DateOnly dateOnly,
            Roles role,
            BranchId? branchId = null);
    }
}
