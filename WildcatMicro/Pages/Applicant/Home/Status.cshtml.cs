using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;
using WildcatMicro.Models.Models.ViewModels;

namespace WildcatMicro.Pages.Applicant.Home
{
    public class StatusModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatusModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<QuestionForcedResponsesVM> QuestionObj = new List<QuestionForcedResponsesVM>();
        public ApplicationUser ApplicationUser;
        public QuestionResponses responseObj;
        public void OnGet()
        {
            ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(a => a.Email == User.Identity.Name);
            int category = 3;
            IEnumerable<Questions> questions = _unitOfWork.Questions.GetAll(c => c.QuestionCategoryId == category);
            foreach (var tempQuestion in questions)
            {
                QuestionForcedResponsesVM questionForcedResponsesVM = new QuestionForcedResponsesVM()
                {
                    Question = tempQuestion,
                    ResponseList = _unitOfWork.ForceResponse.GetAll(a => a.QuestionId == tempQuestion.QuestionId)
                    .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.Response, Value = x.Response }).ToList()
                };
                QuestionObj.Add(questionForcedResponsesVM);
            }
        }
    }
}
