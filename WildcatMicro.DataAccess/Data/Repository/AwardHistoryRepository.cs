using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class AwardHistoryRepository : Repository<AwardHistory>, IAwardHistoryRepository
    {

        private readonly ApplicationDBContext _db;

        public AwardHistoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAwardHistoryListForDropDown()
        {
            return _db.AwardHistory.Select(i => new SelectListItem()
            {
                Value = i.AwardHistoryId.ToString()
            });
        }

        public void Update(AwardHistory AwardHistory)
        {
            var AwardHistoryFromDB = _db.AwardHistory.FirstOrDefault(s => s.AwardHistoryId == AwardHistory.AwardHistoryId);

            AwardHistoryFromDB.Agreement = AwardHistory.Agreement;
            AwardHistoryFromDB.AwardDate = AwardHistory.AwardDate;
            AwardHistoryFromDB.Amount = AwardHistory.Amount;
            AwardHistoryFromDB.ReqNumber = AwardHistory.ReqNumber;
            AwardHistoryFromDB.MailDate = AwardHistory.MailDate;
            AwardHistoryFromDB.Provider = AwardHistory.Provider;
            AwardHistoryFromDB.AwardType = AwardHistory.AwardType;
            AwardHistoryFromDB.ApplicationId = AwardHistory.ApplicationId;
           
        _db.SaveChanges();
        }
    }
}
