using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IStatusesRepository : IRepository<Statuses>
    {
        IEnumerable<SelectListItem> GetQuestionsListForDropDown();
        void Update(Statuses statuses);
    }
}
