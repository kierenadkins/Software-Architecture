using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Visas
{
    public interface IVisaInformation
    {
        string Overview { get; init; }
        string ApplicationProccess { get; init; }
        string LengthOfStay { get; init; }
    }
}
