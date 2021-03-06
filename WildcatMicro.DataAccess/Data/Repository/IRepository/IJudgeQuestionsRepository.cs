using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IJudgeQuestionsRepository : IRepository<JudgeQuestions>
    {
        IEnumerable<SelectListItem> GetJudgeQuestionsListForDropDown();

        void Update(JudgeQuestions judgeQuestions);
    }
}
