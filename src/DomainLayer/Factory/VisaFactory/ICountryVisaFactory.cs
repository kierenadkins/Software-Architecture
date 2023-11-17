using DomainLayer.Objects.Visas;

namespace DomainLayer.Factory.UserFactory
{
    public interface ICountryVisaFactory
    {
        ICountryVisas CreateCountryVisa(List<IVisa> visas);
    }
}