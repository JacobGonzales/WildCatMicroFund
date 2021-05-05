using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ExternalFundingRepository : Repository<ExternalFunding>, IExternalFundingRepository
    {

        private readonly ApplicationDBContext _db;

        public ExternalFundingRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetExternalFundingListForDropDown()
        {
            return _db.ExternalFunding.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.ExternalFundingId.ToString()
            });
        }

        public void Update(ExternalFunding externalFunding)
        {
            var externalFundFromDB = _db.ExternalFunding.FirstOrDefault(s => s.ExternalFundingId == externalFunding.ExternalFundingId);

            externalFundFromDB.Amount = externalFunding.Amount;
            externalFundFromDB.Source = externalFunding.Source;
            externalFundFromDB.Date = externalFunding.Date;
            externalFundFromDB.ApplicationId = externalFunding.ApplicationId;

            _db.SaveChanges();
        }
    }
}
