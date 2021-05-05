using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IPitchRepository : IRepository<Pitch>
    {
        IEnumerable<SelectListItem> GetPitchListForDropDown();

        void Update(Pitch pitch);
    }
}
