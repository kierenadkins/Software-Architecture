using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Factory.UserFactory
{
    public class CountryVisaFactory : ICountryVisaFactory
    {
        public ICountryVisas CreateCountryVisa(List<IVisa> visas)
        {
            return new CountryVisas(visas);
        }
    }
}