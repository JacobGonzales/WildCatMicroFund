using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IScoringCatagoryRepository : IRepository<ScoringCatagory>
    {
        IEnumerable<SelectListItem> GetScoringCatagoryListForDropDown();

        void Update(ScoringCatagory scoringCatagory);
    }
}
