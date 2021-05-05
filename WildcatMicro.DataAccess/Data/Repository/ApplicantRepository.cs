using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {

        private readonly ApplicationDBContext _db;

        public ApplicantRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicantListForDropDown()
        {
            return _db.Applicant.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.ApplicantId.ToString()
            });
        }

        public void Update(Applicant Applicant)
        {
            var ApplicantFromDB = _db.Applicant.FirstOrDefault(s => s.ApplicantId == Applicant.ApplicantId);

            ApplicantFromDB.BusinessId = Applicant.BusinessId;
            ApplicantFromDB.ApplicationUserId = Applicant.ApplicationUserId;

            _db.SaveChanges();
        }
    }
}
