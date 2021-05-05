using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IBusinessRepository : IRepository<Business>
    {
        IEnumerable<SelectListItem> GetBusinessListForDropDown();

        void Update(Business business);
    }
}