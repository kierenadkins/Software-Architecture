using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Users
{
    [ExcludeFromCodeCoverage]
    public class BranchId
    {
        public Guid Value;
        public BranchId(string id)
        {
            if(id is null)
            {
                Value = Guid.Empty;
                return;
            }

            if (!Guid.TryParse(id, out Value))
            {
                throw new ArgumentException("Branch id not valid");
            }
        }

        public static implicit operator BranchId(string id)
        {
            return new BranchId(id);
        }
    }
}
