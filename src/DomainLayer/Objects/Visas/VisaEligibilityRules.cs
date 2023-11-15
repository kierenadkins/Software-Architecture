namespace DomainLayer.Objects.Visas
{
    public class VisaEligibilityRules : IVisaEligibilityRules
    {
        public VisaEligibilityRules(string eligibility, List<string> eligibleCountries)
        {
            Eligibility = eligibility;
            EligibleCountires = eligibleCountries;
        }

        public string Eligibility { get; init; }
        public List<string> EligibleCountires { get; init; }
    }
}