using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IResponsesRepository : IRepository<QuestionResponses>
    {
        void Update(QuestionResponses Responses);
    }
}
