using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.ValueObjects.Application;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Objects.Applications
{
    public interface IApplication
    {
        Status ApplicationStatus { get; }
        bool? BiometricCompleted { get; }
        BiometricIdentification? BiometricIdentification { get; init; }
        bool BiometricRequired { get; }
        BranchId BranchId { get; init; }
        Documentation Docs { get; init; }
        ApplicationsId Id { get; init; }
        PassportDetails PassportDetails { get; init; }
        PersonalDetails PersonalDetails { get; init; }
        TravelDetails TravelDetails { get; init; }
        UserId UserId { get; init; }
        VisaId VisaId { get; init; }

        void isBiometricCompleted();
        void UpdateStatus(Status status);
    }
}