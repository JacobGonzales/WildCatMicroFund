using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {

        private readonly ApplicationDBContext _db;

        public BusinessRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetBusinessListForDropDown()
        {
            return _db.Business.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(Business business)
        {
            var businessFromDB = _db.Business.FirstOrDefault(s => s.Id == business.Id);

            businessFromDB.Name = business.Name;

            _db.SaveChanges();
        }
    }
}
