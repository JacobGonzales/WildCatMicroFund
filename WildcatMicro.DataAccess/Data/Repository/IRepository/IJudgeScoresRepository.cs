using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IJudgeScoresRepository : IRepository<JudgeScores>
    {
        IEnumerable<SelectListItem> GetJudgeScoresListForDropDown();

        void Update(JudgeScores judgeScores);
    }
}
