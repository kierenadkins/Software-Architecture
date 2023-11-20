using DomainLayer.Enums.UserEnum;
using DomainLayer.Factory.ApplicationFactory;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Applications;
using InfrastructureLayer.Documents.ApplicationDocuments;
using System;
using System.Xml.XPath;

namespace InfrastructureLayer.Mappers.Applications
{
    public class ApplicationMapper : IApplicationMapper
    {

        private readonly IApplicationFactory _applicationFactory;
        public ApplicationMapper(IApplicationFactory applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }
        private AdditionalInformationDocument ToAdditionalInformationDocument(IAdditionalInformation additionalInformation) =>
            new();

        public ApplicationDocument ToApplicationDocument(IApplication application) =>
            new(
                application.Id.Value.ToString(),
                application.UserId.Value.ToString(),
                application.VisaId.Value.ToString(),
                application.BranchId.Value.ToString(),
                ToPersonalDetailsDocument(application.PersonalDetails),
                ToTravelDetailsDocument(application.TravelDetails),
                ToPassportDetailsDocument(application.PassportDetails),
                ToDocumentationDocument(application.Docs),
                application.ApplicationStatus,
                application.BiometricRequired,
                ToIBiometricIdentificationDocument(application.BiometricIdentification),
                application.BiometricCompleted);

        private ChatDocument ToChatDocument(IChat chat) =>
            new(chat.Firstname, chat.Time.ToString(), chat.Message);

        private DocumentationDataDocument ToDocumentationDataDocument(IDocumentationData docData) =>
            new();

        private DocumentationDocument ToDocumentationDocument(IDocumentation doc) =>
            new();

        private BiometricIdentificationDocument ToIBiometricIdentificationDocument(IBiometricIdentification? biometricIdentification) =>
            new();

        private PassportDetailsDocument ToPassportDetailsDocument(IPassportDetails passportDetails) =>
            new(passportDetails.Questions.Select(x => ToQuestionDocument(x)).ToList(), passportDetails.AllQuestionsAnswered);

        private PersonalDetailsDocument ToPersonalDetailsDocument(IPersonalDetails personalDetails) =>
            new(personalDetails.Questions.Select(x => ToQuestionDocument(x)).ToList(), personalDetails.AllQuestionsAnswered);

        private QuestionDocument ToQuestionDocument(IQuestion question) =>
            new(question.ApplicationQuestion, question.QuestionType, "this needs to be set to null", question.CheckBoxOptions, question.SelectOptions);

        private TravelDetailsDocument ToTravelDetailsDocument(ITravelDetails travelDetails) =>
            new(travelDetails.Questions.Select(x => ToQuestionDocument(x)).ToList(), travelDetails.AllQuestionsAnswered);

        private IAdditionalInformation ToAdditionalInformation(AdditionalInformationDocument additionalInformation) => new AdditionalInformation(); //we dont care about this for the prototype

        public IApplication ToApplication(ApplicationDocument application) => _applicationFactory.CreateApplication
            (application.Id,
            application.UserId,
            application.VisaId,
            application.BranchId,
            ToPersonalDetails(application.PersonalDetails),
            ToTravelDetails(application.TravelDetails),
            ToPassportDetails(application.PassportDetails),
            ToDocumentation(application.Docs),
            application.ApplicationStatus
            );

        private BiometricIdentification ToIBiometricIdentification(BiometricIdentificationDocument additionalInformation) => new BiometricIdentification(); // we dont care about this for the prototype

        private Chat ToChat(ChatDocument chat) => new Chat(); // we dont care about this for prototype

        private Documentation ToDocumentation(DocumentationDocument DocumentationDocument) => new Documentation(DocumentationDocument.RequiredDocs);

        private DocumentationData ToDocumentationData(DocumentationDataDocument docData) => new DocumentationData();

        private PassportDetails ToPassportDetails(PassportDetailsDocument passportDetails)
        {
            var questions = passportDetails.Questions.Select(x => ToQuestion(x)).ToList();
            return new PassportDetails(questions);
        }

        private PersonalDetails ToPersonalDetails(PersonalDetailsDocument personalDetails) {
            var questions = personalDetails.Questions.Select(x => ToQuestion(x)).ToList();
            return new PersonalDetails(questions);
        }

        private Question ToQuestion(QuestionDocument question) => 
            new Question(question.ApplicationQuestion, 
                question.QuestionType, 
                question.Answer,
                question.CheckBoxOptions,
                question.SelectOptions);

        private TravelDetails ToTravelDetails(TravelDetailsDocument travelDetails)
        {
            var questions = travelDetails.Questions.Select(x => ToQuestion(x)).ToList();
            return new TravelDetails(questions);
        }
    }
}
