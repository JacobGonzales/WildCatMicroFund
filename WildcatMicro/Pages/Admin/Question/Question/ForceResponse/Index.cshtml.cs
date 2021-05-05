using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WildcatMicro.DataAccess.Data;
using System.Linq;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using WildcatMicro.Models.Models.ViewModels;

namespace WildcatMicro.Pages.Admin.Question.Question.ForceResponse
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public QuestionForcedResponsesVM QuestionObj { get; set; }

        public IActionResult OnGet(int id)
        {
            QuestionObj = new QuestionForcedResponsesVM();
            QuestionObj.Question = _unitOfWork.Questions.GetFirstOrDefault(u => u.QuestionId == id);
            QuestionObj.Responses = _unitOfWork.ForceResponse.GetAll(a => a.QuestionId == id).ToList();
            return Page();
        }
        public IActionResult deleteresponse(int id)
        {
            _unitOfWork.ForceResponse.Remove(id);
            return Page();
        }
    }
}
