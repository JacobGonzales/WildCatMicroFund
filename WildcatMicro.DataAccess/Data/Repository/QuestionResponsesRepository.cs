using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class QuestionResponsesRepository : Repository<QuestionResponses>, IResponsesRepository
    {

        private readonly ApplicationDBContext _db;

        public QuestionResponsesRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(QuestionResponses responses)
        {
            var ResponsesFromDB = _db.Responses.FirstOrDefault(s => s.ResponseId == responses.ResponseId);

            ResponsesFromDB.Response = responses.Response;
            ResponsesFromDB.QuestionsId = responses.QuestionsId;
            ResponsesFromDB.ResponseDate = responses.ResponseDate;
            ResponsesFromDB.ApplicationId = responses.ApplicationId;



            _db.SaveChanges();
        }
    }
}
