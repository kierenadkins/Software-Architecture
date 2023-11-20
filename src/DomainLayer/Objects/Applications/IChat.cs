
namespace DomainLayer.Objects.Applications
{
    public interface IChat
    {
        string Firstname { get; set; }
        string Message { get; set; }
        DateTime Time { get; set; }
    }
}