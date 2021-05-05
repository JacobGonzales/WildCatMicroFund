using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IQuestionCategorysRepository : IRepository<QuestionCategorys>
    {
        IEnumerable<SelectListItem> GetQuestionCategoryListForDropDown();

        void Update(QuestionCategorys QuestionCategorys);
    }
}
