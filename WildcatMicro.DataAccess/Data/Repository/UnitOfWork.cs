using WildcatMicro.DataAccess.Data.Repository.IRepository;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IBusinessRepository Business { get; private set; }
        public IApplicantRepository Applicant { get; private set; }
        public IApplicationRepository Application { get; private set; }
        //
        public IMentorAssignmentRepository MentorAssignment { get; private set; }
        public IAwardHistoryRepository AwardHistory { get; private set; }
        public IJudgeQuestionsRepository JudgeQuestions { get; private set; }
        public IJudgeScoresRepository JudgeScores { get; private set; }
        public IScoringCatagoryRepository ScoringCatagory { get; private set; }
        public IPitchRepository Pitch { get; private set; }
        public IExternalFundingRepository ExternalFunding { get; private set; }
        public IMentorNotesRepository MentorNotes { get; private set; }

        public IQuestionsRepository Questions { get; private set; }
        public IQuestionCategorysRepository QuestionCategorys { get; private set; }
        public IResponsesRepository Responses { get; private set; }
        public IForceResponseRepository ForceResponse { get; private set; }
        public IStatusesRepository StatusesRepository { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Applicant = new ApplicantRepository(_db);
            Application = new ApplicationRepository(_db);
            Business = new BusinessRepository(_db);
            MentorAssignment = new MentorAssignmentRepository(_db);
            AwardHistory = new AwardHistoryRepository(_db);
            JudgeQuestions = new JudgeQuestionsRepository(_db);
            JudgeScores = new JudgeScoresRepository(_db);
            ScoringCatagory = new ScoringCatagoryRepository(_db);
            Pitch = new PitchRepository(_db);
            ExternalFunding = new ExternalFundingRepository(_db);
            MentorNotes = new MentorNotesRepository(_db);

            Questions = new QuestionsRepository(_db);
            QuestionCategorys = new QuestionCategorysRepository(_db);
            Responses = new QuestionResponsesRepository(_db);
            ForceResponse = new ForceResponseRepository(_db);
            StatusesRepository = new StatusesRepository(_db); 
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
