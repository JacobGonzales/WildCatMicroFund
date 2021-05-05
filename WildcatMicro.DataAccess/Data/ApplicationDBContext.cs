using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WildcatMicro.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<WildcatMicro.Models.Business> Business { get; set; }
        public DbSet<WildcatMicro.Models.Applicant> Applicant { get; set; }
        public DbSet<WildcatMicro.Models.Application> Application { get; set; }
        public DbSet<WildcatMicro.Models.MentorAssignment> MentorAssignment { get; set; }
        public DbSet<WildcatMicro.Models.AwardHistory> AwardHistory { get; set; }
        public DbSet<WildcatMicro.Models.JudgeQuestions> JudgeQuestions { get; set; }
        public DbSet<WildcatMicro.Models.JudgeScores> JudgeScores { get; set; }
        public DbSet<WildcatMicro.Models.ScoringCatagory> ScoringCatagory { get; set; }
        public DbSet<WildcatMicro.Models.Pitch> Pitch { get; set; }
        public DbSet<WildcatMicro.Models.ExternalFunding> ExternalFunding { get; set; }
        public DbSet<WildcatMicro.Models.MentorNotes> MentorNotes { get; set; }
        public DbSet<WildcatMicro.Models.Questions> Questions { get; set; }
        public DbSet<WildcatMicro.Models.QuestionCategorys> QuestionCategorys { get; set; }
        public DbSet<WildcatMicro.Models.QuestionResponses> Responses { get; set; }
        public DbSet<WildcatMicro.Models.ForceResponse> ForceResponse { get; set; }
        public DbSet<WildcatMicro.Models.Statuses> Statuses { get; set; }
    }
}
