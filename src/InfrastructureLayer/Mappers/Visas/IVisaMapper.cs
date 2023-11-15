using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using InfrastructureLayer.Documents.UserDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Mappers.Visas
{
    public interface IVisaMapper
    {
        //To Model
        IVisa ToVisaModel(VisaDocument visaDoc);
        VisaDocumentationRequirements ToVisaDocumentationRequirementsModel(VisaDocumentationRequirementsDocument documentation);
        VisaEligibilityRules ToVisaEligibilityRuleModel(VisaEligibilityRulesDocument eligibility);
        VisaInformation ToVisaInformationModel(VisaInformationDocument information);

        //There could be a point where we may want to store suggestions in the system so people can review them later, so i have left these in
        VisaDocument ToVisaDocument(IVisa visa);
        VisaDocumentationRequirementsDocument ToVisaDocumentationRequirementsDocument(IVisaDocumentationRequirements documentation);
        VisaEligibilityRulesDocument ToVisaEligibilityRuleDocument(IVisaEligibilityRules eligibility);
        VisaInformationDocument ToVisaInformationDocument(IVisaInformation information);

    }
}
