using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WildcatMicro.Pages.Admin.Question.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.QuestionCategorys QuestionCategorysObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            QuestionCategorysObj = new Models.QuestionCategorys();

            if (id != null)
            {
                QuestionCategorysObj = _unitOfWork.QuestionCategorys.GetFirstOrDefault(u => u.QuestionCategoryId == id);
                if (QuestionCategorysObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(QuestionCategorysObj.QuestionCategoryId == 0)
            {
                _unitOfWork.QuestionCategorys.Add(QuestionCategorysObj);
            }
            else
            {
                _unitOfWork.QuestionCategorys.Update(QuestionCategorysObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");

        }
    }
}