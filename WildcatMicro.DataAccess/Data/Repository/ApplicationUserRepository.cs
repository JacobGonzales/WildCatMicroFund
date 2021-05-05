using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDBContext _db;

        public ApplicationUserRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }      
    }
}
