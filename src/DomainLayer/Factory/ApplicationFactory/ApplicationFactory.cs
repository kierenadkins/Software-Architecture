using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Application;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Factory.ApplicationFactory
{
    public class ApplicationFactory : IApplicationFactory
    {
        public IApplication CreateApplication(ApplicationsId id1,
            UserId? id2, 
            VisaId id3, 
            BranchId? id4, 
            PersonalDetails personalDetails, 
            TravelDetails travelDetails,
            PassportDetails passportDetails,
            Documentation docsDetails,
            Status status

            )
        {
            return new Application(
                id1,
                id2,
                id3,
                id4,
                personalDetails,
                travelDetails,
                passportDetails,
                docsDetails,
                status,
                biometricRequired: false,
                new BiometricIdentification(),
                biometricCompleted: false
            );
        }
    }
}