using System;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }

        IBusinessRepository Business { get; }

        IApplicantRepository Applicant { get; }
        IApplicationRepository Application { get; }

        //
        IMentorAssignmentRepository MentorAssignment { get; }
        IAwardHistoryRepository AwardHistory { get; }
        IJudgeQuestionsRepository JudgeQuestions { get; }
        IJudgeScoresRepository JudgeScores { get; }
        IScoringCatagoryRepository ScoringCatagory { get; }
        IPitchRepository Pitch { get; }
        IExternalFundingRepository ExternalFunding { get; }
        IMentorNotesRepository MentorNotes { get; }

        IQuestionsRepository Questions  { get; }
        IQuestionCategorysRepository QuestionCategorys { get; }
        IResponsesRepository Responses { get; }

        IForceResponseRepository ForceResponse { get; }
        IStatusesRepository StatusesRepository { get; }
        void Save();
    }
}
