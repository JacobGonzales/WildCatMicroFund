using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;
using WildcatMicro.Models.ViewModels;

namespace WildcatMicro.Pages.Admin.JudgeQuestions
{
    public class UpsertModel : PageModel
    {
            private readonly IUnitOfWork _unitOfWork;

    public UpsertModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

        [BindProperty]
    public JudgeQuestionsVM JudgeQuestionsObj { get; set; }

    public IActionResult OnGet(int? id)
    {

            JudgeQuestionsObj = new JudgeQuestionsVM
            {
                JudgeQuestions = new Models.JudgeQuestions(),
                Questions = _unitOfWork.Questions.GetQuestionsListForDropDown()
            };

            if (id != null)
        {
                JudgeQuestionsObj.JudgeQuestions = _unitOfWork.JudgeQuestions.GetFirstOrDefault(u => u.JudgeQuestionsId == id);
            if (JudgeQuestionsObj.JudgeQuestions == null)
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
        if (JudgeQuestionsObj.JudgeQuestions.JudgeQuestionsId == 0)
        {
            _unitOfWork.JudgeQuestions.Add(JudgeQuestionsObj.JudgeQuestions);
        }
        else
        {
            _unitOfWork.JudgeQuestions.Update(JudgeQuestionsObj.JudgeQuestions);
        }
        _unitOfWork.Save();
        return RedirectToPage("./Index");

    }
}
}
