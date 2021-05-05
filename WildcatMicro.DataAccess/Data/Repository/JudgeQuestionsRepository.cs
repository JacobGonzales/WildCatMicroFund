using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class JudgeQuestionsRepository : Repository<JudgeQuestions>, IJudgeQuestionsRepository
    {
        private readonly ApplicationDBContext _db;

        public JudgeQuestionsRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetJudgeQuestionsListForDropDown()
        {
            return _db.JudgeQuestions.Select(i => new SelectListItem()
            {
                Value = i.JudgeQuestionsId.ToString(),
                Text = i.Questions.Question.ToString()
            });
        }

        public void Update(JudgeQuestions judgeQuestions)
        {
            var judgeQuestionsFromDb = _db.JudgeQuestions.FirstOrDefault(m => m.JudgeQuestionsId == judgeQuestions.JudgeQuestionsId);

            //judgeScoresFromDb.JudgeScore = judgeScores.JudgeScore;
            judgeQuestionsFromDb.Weight = judgeQuestions.Weight;
            judgeQuestionsFromDb.QuestionId = judgeQuestions.QuestionId;

            _db.SaveChanges();
        }
    }
}
