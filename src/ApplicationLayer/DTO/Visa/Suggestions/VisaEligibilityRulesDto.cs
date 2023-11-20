namespace ApplicationLayer.DTO.Visa.Suggestions
{
    public class VisaEligibilityRulesDto
    {
        public VisaEligibilityRulesDto(string eligibility, List<string> eligibleCountries)
        {
            Eligibility = eligibility;
            EligibleCountires = eligibleCountries;
        }

        public string Eligibility { get; init; }
        public List<string> EligibleCountires { get; init; }
    }
}