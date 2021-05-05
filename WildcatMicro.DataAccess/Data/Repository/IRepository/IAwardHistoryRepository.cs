using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IAwardHistoryRepository : IRepository<AwardHistory>
    {
        IEnumerable<SelectListItem> GetAwardHistoryListForDropDown();

        void Update(AwardHistory AwardHistory);
    }
}
