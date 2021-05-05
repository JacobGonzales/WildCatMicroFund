using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ForceResponseRepository : Repository<ForceResponse>, IForceResponseRepository
    {

        private readonly ApplicationDBContext _db;

        public ForceResponseRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(ForceResponse forceResponse)
        {
            var ForceResponseFromDB = _db.ForceResponse.FirstOrDefault(s => s.QuestionId == forceResponse.QuestionId);

            ForceResponseFromDB.QuestionId = forceResponse.QuestionId;
            ForceResponseFromDB.Response = forceResponse.Response;

            _db.SaveChanges();
        }
    }
}
