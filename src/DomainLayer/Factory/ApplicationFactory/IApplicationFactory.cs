using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.Objects.Applications;
using DomainLayer.ValueObjects.Application;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Factory.ApplicationFactory
{
    public interface IApplicationFactory
    {
        IApplication CreateApplication(ApplicationsId id1, 
            UserId? id2,
            VisaId id3,
            BranchId? id4,
            PersonalDetails personalDetails,
            TravelDetails travelDetails,
            PassportDetails passportDetails,
            Documentation docsDetails,
            Status status4);
    }
}