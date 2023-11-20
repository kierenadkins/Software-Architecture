using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class TravelDetailsDocument
    {
        public TravelDetailsDocument(List<QuestionDocument> questions, bool allQuestionsAnswered)
        {
            Questions = questions;
            AllQuestionsAnswered = allQuestionsAnswered;
        }

        public List<QuestionDocument> Questions { get; init; } = new List<QuestionDocument>();

        public bool AllQuestionsAnswered { get; set; }
    }
}
