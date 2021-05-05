using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {

        private readonly ApplicationDBContext _db;

        public ApplicationRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicationListForDropDown()
        {
            return _db.Application.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(Application Application)
        {
            var ApplicationFromDB = _db.Application.FirstOrDefault(s => s.Id == Application.Id);
    
            ApplicationFromDB.ApplicantId = Application.ApplicantId;
            ApplicationFromDB.ApplicationDate = Application.ApplicationDate;
            ApplicationFromDB.Statuses = Application.Statuses;
            ApplicationFromDB.ApplicationStatusDescription = Application.ApplicationStatusDescription;

            _db.SaveChanges();
        }
    }
}
