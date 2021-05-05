using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WildcatMicro.Pages.Admin.Question.Question
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public QuestionVM QuestionObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            QuestionObj = new QuestionVM
            {
                Question = new Models.Questions(),
                QuestionCategory = _unitOfWork.QuestionCategorys.GetQuestionCategoryListForDropDown()
            };

            if (id != null)
            {
                QuestionObj.Question = _unitOfWork.Questions.GetFirstOrDefault(u => u.QuestionId == id);
                if (QuestionObj.Question == null)
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
            if(QuestionObj.Question.QuestionId == 0)
            {
                _unitOfWork.Questions.Add(QuestionObj.Question);
            }
            else
            {
                _unitOfWork.Questions.Update(QuestionObj.Question);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");

        }
    }
}