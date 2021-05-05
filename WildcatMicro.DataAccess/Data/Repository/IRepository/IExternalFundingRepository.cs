using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IExternalFundingRepository : IRepository<ExternalFunding>
    {
        IEnumerable<SelectListItem> GetExternalFundingListForDropDown();

        void Update(ExternalFunding externalFunding);
    }
}
