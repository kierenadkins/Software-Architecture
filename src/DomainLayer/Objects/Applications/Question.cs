using DomainLayer.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class Question : IQuestion
    {
        public Question(string applicationQuestion, QuestionType questionType, string? answer = null, List<string>? checkBoxOptions = null, List<string>? selectOptions = null)
        {
            ApplicationQuestion = applicationQuestion;
            QuestionType = questionType;
            CheckBoxOptions = checkBoxOptions;
            SelectOptions = selectOptions;
            Answer = answer;
        }

        public string ApplicationQuestion { get; init; }
        public QuestionType QuestionType { get; set; }
        public List<string>? CheckBoxOptions { get; set; } = new List<string>();

        public List<string>? SelectOptions { get; set; } = new List<string>();

        private string? Answer { get; set; }

        public bool Answered()
        {
            return Answer != null;
        }

        public void AnswerQuestion(string answer)
        {
            switch (QuestionType)
            {
                case QuestionType.CheckBox:
                    if (CheckBoxOptions!.Contains(answer))
                    {
                        Answer = answer;
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect Option");
                    }
                    break;
                case QuestionType.SelectBox:
                    if (SelectOptions!.Contains(answer))
                    {
                        Answer = answer;
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect Option");
                    }
                    break;

                //more logic should be put here
                default: Answer = answer ?? string.Empty; break;


            }
        }
    }
}