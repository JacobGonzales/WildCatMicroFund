using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        IEnumerable<SelectListItem> GetApplicantListForDropDown();

        void Update(Applicant Applicant);
    }
}
