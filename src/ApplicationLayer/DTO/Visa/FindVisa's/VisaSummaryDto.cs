using DomainLayer.ValueObjects.Visa;

namespace DomainLayer.Objects.Visas
{
    public class VisaSummaryDto
    {
        internal VisaSummaryDto(
            Guid id, 
            string title,
            string country, 
            string type,
            string purpose)
        {
            Id = id;
            Title = title;
            Country = country;
            Type = type;
            Purpose = purpose;
        }

        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Country { get; init; }
        public string Type { get; init; }
        public string Purpose { get; init; }
      
    }
}