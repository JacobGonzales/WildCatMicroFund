using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class QuestionCategorysRepository : Repository<QuestionCategorys>, IQuestionCategorysRepository
    {

        private readonly ApplicationDBContext _db;

        public QuestionCategorysRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetQuestionCategoryListForDropDown()
        {
            return _db.QuestionCategorys.Select(i => new SelectListItem()
            {
                Text = i.Category,
                Value = i.QuestionCategoryId.ToString()
            });
        }

        public void Update(QuestionCategorys questionCategorys)
        {
            var QuestionCategorysFromDB = _db.QuestionCategorys.FirstOrDefault(s => s.QuestionCategoryId == questionCategorys.QuestionCategoryId);

            QuestionCategorysFromDB.Category = questionCategorys.Category;
            

            _db.SaveChanges();
        }
    }
}
