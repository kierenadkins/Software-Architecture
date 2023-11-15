

using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Factory.UserFactory
{
    public interface IVisaFactory
    {
        IVisa CreateVisa(VisaId id,
            VisaTitle title,
            VisaInformation information,
            VisaEligibilityRules eligibilityRules,
            VisaDocumentationRequirements documentation,
            VisaCountry country,
            VisaType type,
            VisaPurpose purpose);
    }
}
