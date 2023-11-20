
namespace DomainLayer.Objects.Applications
{
    public interface IAdditionalInformation
    {
        List<Chat> chat { get; set; }

        void addNewChat(string firstname, DateTime time, string message);
    }
}