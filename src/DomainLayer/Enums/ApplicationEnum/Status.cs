using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums.ApplicationEnum
{
    public enum Status
    {
        Incomplete,
        Pending,
        RequiresBiometricAuthentication,
        NeedsMoreInformation,
        Rejected,
        Approved
    }
}
