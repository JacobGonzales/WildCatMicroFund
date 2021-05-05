using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;
using WildcatMicro.Models.Models.ViewModels;

namespace WildcatMicro.Pages.Applicant.Home
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public List<QuestionForcedResponsesVM> QuestionObj = new List<QuestionForcedResponsesVM>();
        public ApplicationUser ApplicationUser;
        public QuestionResponses responseObj;
        public Business BusinessObj;
        public Models.Applicant ApplicantObj;
        public Application ApplicationObj;

        public void OnGet()
        {
            
            ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(a=> a.Email == User.Identity.Name);
            int category = 3;
            IEnumerable<Questions> questions = _unitOfWork.Questions.GetAll(c => c.QuestionCategoryId == category);
            foreach(var tempQuestion in questions)
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
        public IActionResult OnPost()
        {

            int category = 3;
            IEnumerable<Questions> questions = _unitOfWork.Questions.GetAll(c => c.QuestionCategoryId == category);

            string userId = Request.Form["userId"].ToString();
            BusinessObj = new Business();
            BusinessObj.Name = Request.Form["10"];
           
            _unitOfWork.Business.Add(BusinessObj);
            _unitOfWork.Save();

            ApplicantObj = new Models.Applicant();
            ApplicantObj.ApplicationUserId = userId;
            ApplicantObj.BusinessId = BusinessObj.Id;
            
            _unitOfWork.Applicant.Add(ApplicantObj);
            _unitOfWork.Save();


            ApplicationObj = new Application();
            ApplicationObj.ApplicationDate = DateTime.Now;
            
            ApplicationObj.ApplicantId = ApplicantObj.ApplicantId;
            ApplicationObj.StatusId = 3;

            _unitOfWork.Application.Add(ApplicationObj);
            _unitOfWork.Save();

            
            foreach (var applicationQuestion in questions)
            {
                if(applicationQuestion.QuestionId != 10)
                {
                    responseObj = new QuestionResponses();
                    responseObj.QuestionsId = applicationQuestion.QuestionId;
                    responseObj.Response = Request.Form[applicationQuestion.QuestionId.ToString()].ToString();
                    responseObj.ResponseDate = DateTime.Today;
                    responseObj.ApplicationId = ApplicationObj.Id;
                    _unitOfWork.Responses.Add(responseObj);
                }                
            }

            _unitOfWork.Save();
            return RedirectToPage("./Completion");
        }
        
    }
}