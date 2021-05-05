using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class MentorNotesRepository : Repository<MentorNotes>, IMentorNotesRepository
    {

        private readonly ApplicationDBContext _db;

        public MentorNotesRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetMentorListListForDropDown()
        {
            return _db.MentorNotes.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.MentorNotesId.ToString()
            });
        }

        public void Update(MentorNotes mentorNotes)
        {
            var mentorNotesFromDB = _db.MentorNotes.FirstOrDefault(s => s.MentorNotesId == mentorNotes.MentorNotesId);

            mentorNotesFromDB.MentorAssignmentId = mentorNotes.MentorAssignmentId;
            mentorNotesFromDB.Notes = mentorNotes.Notes;
            mentorNotesFromDB.MeetingDate = mentorNotes.MeetingDate;

            _db.SaveChanges();
        }
    }
}
