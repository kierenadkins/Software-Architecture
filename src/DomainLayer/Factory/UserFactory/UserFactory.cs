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
    public class UserFactory : IUserFactory
    {
        public IUser CreateUserAccount(UserId id, UserFirstName firstName, UserLastName lastName, UserEmail email, UserPassword password, string salt, bool accountActive, DateOnly dateOnly, Roles role, BranchId? branchId = null)
        {
            switch (role)
            {
                case Roles.VisaApplicant:
                    return new VisaApplicant(id, firstName, lastName, email, password, salt, accountActive, dateOnly, role);
                case Roles.VisaOfficer:
                    return new VisaOfficer(id, firstName, lastName, email, password, salt, accountActive, dateOnly, role, branchId);
                default: break;
            }

            throw new Exception("Invalid User Type");
        }
    }
}
