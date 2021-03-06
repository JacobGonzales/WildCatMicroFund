using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IApplicationRepository : IRepository<Application>
    {
        IEnumerable<SelectListItem> GetApplicationListForDropDown();

        void Update(Application application);
    }
}
