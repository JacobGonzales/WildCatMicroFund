using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IQuestionsRepository : IRepository<Questions>
    {
        IEnumerable<SelectListItem> GetQuestionsListForDropDown();
        void Update(Questions Questions);
    }
}
