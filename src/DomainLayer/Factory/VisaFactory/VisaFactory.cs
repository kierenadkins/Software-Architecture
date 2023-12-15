using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Factory.UserFactory
{
    public class VisaFactory : IVisaFactory
    {
        public IVisa CreateVisa(VisaId id,
            VisaTitle title,
            VisaInformation information,
            VisaEligibilityRules eligibilityRules,
            VisaDocumentationRequirements documentation,
            VisaCountry country,
            VisaType type,
            VisaPurpose purpose)
        {
            return new Visa(id, title, information, eligibilityRules, documentation, country, type, purpose);
        }
    }
}