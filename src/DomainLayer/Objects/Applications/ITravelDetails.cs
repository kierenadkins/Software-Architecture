
namespace DomainLayer.Objects.Applications
{
    public interface ITravelDetails
    {
        bool AllQuestionsAnswered { get; set; }
        List<Question> Questions { get; init; }

        void AllAnswered();
        void AnswerQuestion(string answer, int index);
    }
}