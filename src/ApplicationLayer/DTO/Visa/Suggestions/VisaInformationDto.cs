namespace ApplicationLayer.DTO.Visa.Suggestions
{
    public class VisaInformationDto
    {
        public VisaInformationDto(string overview, string applicationProccess, string lengthOfStay)
        {
            Overview = overview;
            ApplicationProccess = applicationProccess;
            LengthOfStay = lengthOfStay;
        }

        public string Overview { get; init; }
        public string ApplicationProccess { get; init; }
        public string LengthOfStay { get; init; }
    }
}