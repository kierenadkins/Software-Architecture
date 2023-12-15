using DomainLayer.Objects.Users;
using DomainLayer.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts.Infrastructure
{
    public interface IUsersReadRepository
    {
        Task<IUser?> GetAsync(string email);
        Task<bool> ExistsAsync(string email);

    }
}
