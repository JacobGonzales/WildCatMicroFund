using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IMentorAssignmentRepository : IRepository<MentorAssignment>
    {
        IEnumerable<SelectListItem> GetMentorAssignmentListForDropDown();

        void Update(MentorAssignment MentorAssignment);
    }
}
