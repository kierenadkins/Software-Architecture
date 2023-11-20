using DomainLayer.Enums.UserEnum;

namespace DomainLayer.Objects.Applications
{
    public interface IQuestion
    {
        string ApplicationQuestion { get; init; }
        List<string>? CheckBoxOptions { get; set; }
        QuestionType QuestionType { get; set; }
        List<string>? SelectOptions { get; set; }

        bool Answered();
        void AnswerQuestion(string answer);
    }
}