using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WildcatMicro.Pages.Admin.Question.Question.ForceResponse
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        [BindProperty]
        public Models.ForceResponse ForceResponse { get; set; }
        public IActionResult OnGet(int id, int question)
        {
            ForceResponse = new Models.ForceResponse();
            
            if (question != 0)
            ForceResponse.QuestionId = question;

            if (id != 0)
            {
                ForceResponse = _unitOfWork.ForceResponse.GetFirstOrDefault(a => a.ForceResponseId == id);
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(ForceResponse.ForceResponseId == 0)
            {
                _unitOfWork.ForceResponse.Add(ForceResponse);
            }
            else
            {
                _unitOfWork.ForceResponse.Update(ForceResponse);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index", new { id = ForceResponse.QuestionId });

        }
    }
}