using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Visas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Mappers.Users
{
    public class VisaMapper : IVisaMapper
    {
        private readonly IVisaFactory _visaFactory;
        public VisaMapper(IVisaFactory visaFactory)
        {
            _visaFactory = visaFactory;
        }
        public VisaDocument ToVisaDocument(IVisa visa) =>
            new(visa.Id.Value.ToString(),
                visa.Title.Value,
                ToVisaInformationDocument(visa.Information),
                ToVisaEligibilityRuleDocument(visa.ElgibilityRules),
                ToVisaDocumentationRequirementsDocument(visa.DocumentationRequirements),
                visa.Country.Value,
                visa.Type.Value,
                visa.Purpose.Value
                );


        private VisaDocumentationRequirementsDocument ToVisaDocumentationRequirementsDocument(IVisaDocumentationRequirements documentation) => new
            (documentation.Description);

        private VisaDocumentationRequirements ToVisaDocumentationRequirementsModel(VisaDocumentationRequirementsDocument documentation) => new VisaDocumentationRequirements(
            documentation.Description
            );

        private VisaEligibilityRulesDocument ToVisaEligibilityRuleDocument(IVisaEligibilityRules eligibility) =>
            new(eligibility.Eligibility, 
                eligibility.EligibleCountires
                );

        private VisaEligibilityRules ToVisaEligibilityRuleModel(VisaEligibilityRulesDocument eligibility) => new VisaEligibilityRules(
            eligibility.Eligibility,
            eligibility.EligibleCountires);

        private VisaInformationDocument ToVisaInformationDocument(IVisaInformation information) =>
            new(information.Overview,
                information.ApplicationProccess,
                information.LengthOfStay);

        private VisaInformation ToVisaInformationModel(VisaInformationDocument information) => new VisaInformation(
            information.Overview,
            information.ApplicationProccess,
            information.LengthOfStay
            );
        public IVisa ToVisaModel(VisaDocument visaDoc) => _visaFactory.CreateVisa(
            visaDoc.Id,
            visaDoc.Title,
            ToVisaInformationModel(visaDoc.Information),
            ToVisaEligibilityRuleModel(visaDoc.ElgibilityRules),
            ToVisaDocumentationRequirementsModel(visaDoc.DocumentationRequirements),
            visaDoc.Country,
            visaDoc.VisaType,
            visaDoc.Purpose
            );
    }
}
