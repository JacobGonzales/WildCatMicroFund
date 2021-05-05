using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class MentorAssignmentRepository : Repository<MentorAssignment>, IMentorAssignmentRepository
    {

        private readonly ApplicationDBContext _db;

        public MentorAssignmentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetMentorAssignmentListForDropDown()
        {
            return _db.MentorAssignment.Select(i => new SelectListItem()
            {
                Value = i.MentorAssignmentId.ToString()
            });
        }

        public void Update(MentorAssignment MentorAssignment)
        {
            var MentorAssignmentFromDB = _db.MentorAssignment.FirstOrDefault(s => s.MentorAssignmentId == MentorAssignment.MentorAssignmentId);        
            MentorAssignmentFromDB.DateAssigned = MentorAssignment.DateAssigned;
            MentorAssignmentFromDB.ApprovedToPitchDate = MentorAssignment.ApprovedToPitchDate;
            MentorAssignmentFromDB.ApplicationId = MentorAssignment.ApplicationId;
            MentorAssignmentFromDB.ApplicationUserId = MentorAssignment.ApplicationUserId;
            MentorAssignmentFromDB.enabled = MentorAssignment.enabled;
            _db.SaveChanges();
        }
    }
}
