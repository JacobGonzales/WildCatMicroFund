using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ScoringCatagoryRepository : Repository<ScoringCatagory>, IScoringCatagoryRepository
    {

        private readonly ApplicationDBContext _db;

        public ScoringCatagoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetScoringCatagoryListForDropDown()
        {
            return _db.ScoringCatagory.Select(i => new SelectListItem()
            {
                
                Value = i.ScoringCatagoryId.ToString()
            });
        }

        public void Update(ScoringCatagory scoringCatagory)
        {
            var scoreCategoryFromDb = _db.ScoringCatagory.FirstOrDefault(m => m.ScoringCatagoryId == scoringCatagory.ScoringCatagoryId);

            scoreCategoryFromDb.Description = scoringCatagory.Description;

            _db.SaveChanges();
        }
    }
}
