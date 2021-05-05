using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IForceResponseRepository : IRepository<ForceResponse>
    {
        void Update(ForceResponse ForceResponse);
    }
}
