using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Application;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    internal class Application : IApplication
    {
        public Application(ApplicationsId id, UserId? userId, VisaId? visaId, BranchId branchId, PersonalDetails personalDetails, TravelDetails travelDetails, PassportDetails passportDetails, Documentation docs, Status applicationStatus, bool biometricRequired = false, BiometricIdentification? biometricIdentification = null, bool? biometricCompleted = false)
        {
            Id = id;
            UserId = userId;
            VisaId = visaId;
            BranchId = branchId;
            PersonalDetails = personalDetails;
            TravelDetails = travelDetails;
            PassportDetails = passportDetails;
            Docs = docs;
            BiometricIdentification = biometricIdentification;
            ApplicationStatus = applicationStatus;
            BiometricRequired = biometricRequired;
            BiometricCompleted = biometricCompleted ?? throw new ArgumentNullException(nameof(biometricCompleted));
        }

        public ApplicationsId Id { get; init; }
        public UserId? UserId { get; init; }
        public VisaId VisaId { get; init; }
        public BranchId? BranchId { get; init; }

        public PersonalDetails PersonalDetails { get; init; }

        public TravelDetails TravelDetails { get; init; }

        public PassportDetails PassportDetails { get; init; }

        public Documentation Docs { get; init; }

        public BiometricIdentification? BiometricIdentification { get; init; }

        public Status ApplicationStatus { get; private set; }

        public bool BiometricRequired { get; private set; }

        public bool? BiometricCompleted { get; private set; }

        public void isBiometricCompleted()
        {
            if (BiometricIdentification != null)
            {
                BiometricRequired = true;
            }
        }

        public void UpdateStatus(Status status)
        {
            ApplicationStatus = status;
        }
    }
}
