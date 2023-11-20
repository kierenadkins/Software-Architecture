using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Application
{
    [ExcludeFromCodeCoverage]
    public class ApplicationsId
    {
        public Guid Value;
        public ApplicationsId(string id)
        {
            if (!Guid.TryParse(id, out Value))
            {
                throw new ArgumentException("User Id not valid");
            }
        }


        public static implicit operator ApplicationsId(string id)
        {
            return new ApplicationsId(id);
        }
    }
}
