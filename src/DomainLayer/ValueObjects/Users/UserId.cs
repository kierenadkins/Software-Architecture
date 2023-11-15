using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{
    [ExcludeFromCodeCoverage]
    public class UserId
    {
        public Guid Value;
        public UserId(string id)
        {
            if (!Guid.TryParse(id, out Value))
            {
                throw new ArgumentException("User Id not valid");
            }
        }

        public static implicit operator UserId(string id)
        {
            return new UserId(id);
        }
    }
}
