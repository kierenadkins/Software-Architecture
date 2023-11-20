using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Objects.Visas
{
    public class CountryVisaDto
    {
        internal CountryVisaDto(List<VisaSummaryDto> visas)
        {
            countryVisas = visas;
        }

        public List<VisaSummaryDto> countryVisas { get; set; }
      
    }
}