using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IMentorNotesRepository : IRepository<MentorNotes>
    {
        IEnumerable<SelectListItem> GetMentorListListForDropDown();

        void Update(MentorNotes mentorNotes);
    }
}
