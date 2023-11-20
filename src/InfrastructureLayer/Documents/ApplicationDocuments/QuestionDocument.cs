using DomainLayer.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Documents.ApplicationDocuments
{
    public class QuestionDocument
    {
        public QuestionDocument(string applicationQuestion, QuestionType questionType, string answer, List<string>? checkBoxOptions = null, List<string>? selectOptions = null)
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

        public string Answer { get; set; }

      
    }
}