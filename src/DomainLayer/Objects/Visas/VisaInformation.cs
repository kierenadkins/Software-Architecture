namespace DomainLayer.Objects.Visas
{
    public class VisaInformation : IVisaInformation
    {
        public VisaInformation(string overview, string applicationProccess, string lengthOfStay)
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