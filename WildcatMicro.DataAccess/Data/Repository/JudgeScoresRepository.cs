using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class JudgeScoresRepository : Repository<JudgeScores>, IJudgeScoresRepository
    {
        private readonly ApplicationDBContext _db;

        public JudgeScoresRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetJudgeScoresListForDropDown()
        {
            return _db.JudgeScores.Select(i => new SelectListItem()
            {
                Value = i.JudgeScoresId.ToString()
            });
        }

        public void Update(JudgeScores judgeScores)
        {
            var judgeScoresFromDb = _db.JudgeScores.FirstOrDefault(m => m.JudgeScoresId == judgeScores.JudgeScoresId);

            judgeScoresFromDb.JudgeQuestionsId = judgeScores.JudgeQuestionsId;
            judgeScoresFromDb.PitchId = judgeScores.PitchId;
            judgeScoresFromDb.Score = judgeScores.Score;
            judgeScoresFromDb.Comment = judgeScores.Comment;

            _db.SaveChanges();
        }
    }
}
