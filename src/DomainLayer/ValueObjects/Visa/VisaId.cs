using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects.Visa
{
    [ExcludeFromCodeCoverage]
    public class VisaId
    {
        public Guid Value;
        public VisaId(string id)
        {
            if (!Guid.TryParse(id, out Value))
            {
                throw new ArgumentException("User Id not valid");
            }
        }

        public static implicit operator VisaId(string id)
        {
            return new VisaId(id);
        }
    }
}
