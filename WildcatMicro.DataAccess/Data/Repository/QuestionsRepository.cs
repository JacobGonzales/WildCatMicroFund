using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class QuestionsRepository : Repository<Questions>, IQuestionsRepository
    {

        private readonly ApplicationDBContext _db;      

        public QuestionsRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetQuestionsListForDropDown()
        {
            //var category = _db.QuestionCategorys.Where(x => x.Category.Equals("Judge"));
            int categoryId = 4;

            List<SelectListItem> items = new List<SelectListItem>();

            var cols = _db.Questions.ToList().FindAll(x => x.QuestionCategoryId.Equals(categoryId));

            foreach(var col in cols)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = col.Question,
                    Value = col.QuestionId.ToString()
                };

                items.Add(item);
            }

            return items;

            //return _db.Questions.Select(i => new SelectListItem()
            //{
            //    Text = i.Question,
            //    Value = i.QuestionId.ToString()
            //});
        }

        public void Update(Questions questions)
        {
            var QuestionsFromDB = _db.Questions.FirstOrDefault(s => s.QuestionId == questions.QuestionId);

            QuestionsFromDB.QuestionCategoryId = questions.QuestionCategoryId;
            QuestionsFromDB.Question = questions.Question;
            QuestionsFromDB.Order = questions.Order;
            QuestionsFromDB.Type = questions.Type;            
            _db.SaveChanges();
        }
    }
}
