using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class PassportDetails : IPassportDetails
    {
        public PassportDetails(List<Question> questions)
        {
            Questions = questions;
            AllAnswered();
        }

        public bool AllQuestionsAnswered { get; set; }
        public List<Question> Questions { get; init; }

        public void AllAnswered()
        {
            AllQuestionsAnswered = Questions.All(x => x.Answered());
        }

        public void AnswerQuestion(string answer, int index)
        {
            Questions[index].AnswerQuestion(answer);
            AllAnswered();
        }
    }
}
