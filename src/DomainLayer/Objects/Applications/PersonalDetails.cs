using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Applications
{
    public class PersonalDetails : IPersonalDetails
    {
        public PersonalDetails(List<Question> questions)
        {
            Questions = questions;
            AllAnswered();
        }

        public List<Question> Questions { get; init; } = new List<Question>();

        public bool AllQuestionsAnswered { get; set; }

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
