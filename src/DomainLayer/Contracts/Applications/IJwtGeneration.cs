using DomainLayer.Objects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts.Applications
{
    public interface IJwtGeneration
    {
        public string CreateToken(IUser user);
    }
}
