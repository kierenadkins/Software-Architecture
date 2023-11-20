using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.Enums.UserEnum;
using DomainLayer.ValueObjects.Users;
using DomainLayer.ValueObjects.Visa;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class ApplicationDocument : Item
    {
        public ApplicationDocument(
            string id, 
            string userId, 
            string visaId, 
            string branchId,
            PersonalDetailsDocument personalDetails,
            TravelDetailsDocument travelDetails,
            PassportDetailsDocument passportDetails,
            DocumentationDocument docs,
            Status applicationStatus, 
            bool biometricRequired = false,
            BiometricIdentificationDocument? biometricIdentification = null,
            bool? biometricCompleted = false)
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
            BiometricCompleted = biometricCompleted;
        }
        public string PartitionKey => Id;
        public string UserId { get; set; }
        public string VisaId { get; set; }
        public string BranchId { get; set; }

        public PersonalDetailsDocument PersonalDetails { get; set; }

        public TravelDetailsDocument TravelDetails { get; set; }

        public PassportDetailsDocument PassportDetails { get; set; }

        public DocumentationDocument Docs { get; set; }

        public BiometricIdentificationDocument? BiometricIdentification { get; set; }

        public Status ApplicationStatus { get; set; }

        public bool BiometricRequired { get; set; }

        public bool? BiometricCompleted { get; set; }
    }
}
