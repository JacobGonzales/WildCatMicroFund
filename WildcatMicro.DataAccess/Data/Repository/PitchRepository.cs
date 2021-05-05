using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class PitchRepository : Repository<Pitch>, IPitchRepository
    {

        private readonly ApplicationDBContext _db;

        public PitchRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPitchListForDropDown()
        {
            return _db.Pitch.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.PitchId.ToString()
            });
        }

        public void Update(Pitch pitch)
        {
            var pitchFromDB = _db.Pitch.FirstOrDefault(s => s.PitchId == pitch.PitchId);

            pitchFromDB.PitchDate = pitch.PitchDate;
            pitchFromDB.ApplicationId = pitch.ApplicationId;

            _db.SaveChanges();
        }
    }
}
