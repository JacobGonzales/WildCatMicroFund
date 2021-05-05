using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class StatusesRepository : Repository<Statuses>, IStatusesRepository
    {

        private readonly ApplicationDBContext _db;

        public StatusesRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetQuestionsListForDropDown()
        {
            return _db.Statuses.Select(i => new SelectListItem()
            {
                Text = i.Status,
                Value = i.StatusId.ToString()
            });
        }

        public void Update(Statuses statuses)
        {
            var StatusFromDB = _db.Statuses.FirstOrDefault(s => s.StatusId == statuses.StatusId);

            StatusFromDB.StatusId = statuses.StatusId;
            StatusFromDB.Status = statuses.Status;

            _db.SaveChanges();
        }
    }
}
