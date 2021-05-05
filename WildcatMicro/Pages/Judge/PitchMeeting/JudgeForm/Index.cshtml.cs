using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.Pages.Judge.PitchMeeting.JudgeForm
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Models.JudgeQuestions> JudgeQuestionsList { get; set; }

        public JudgeScores JudgeScoresObj { get; set; }

        public Pitch PitchObj { get; set; }
        
        [BindProperty]
        public Application ApplicationObj { get; set; }

        public Models.Applicant ApplicantObj { get; set; }
        public string name;

        public IActionResult OnGet(int? id)
        {

            string tempId = _unitOfWork.Applicant.GetFirstOrDefault(a => a.ApplicantId == id).ApplicationUserId;
            name = _unitOfWork.ApplicationUser.GetFirstOrDefault(b => b.Id == tempId).FullName;

            JudgeQuestionsList = _unitOfWork.JudgeQuestions.GetAll(null, null, "Questions");

            ApplicationObj = new Application();

            if (id != null)
            {
                ApplicationObj = _unitOfWork.Application.GetFirstOrDefault(u => u.ApplicantId == id);
                if (ApplicationObj == null)
                {
                    return NotFound();
                }
                ApplicantObj = _unitOfWork.Applicant.GetFirstOrDefault(u => u.ApplicantId == id);
                if (ApplicantObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            JudgeQuestionsList = _unitOfWork.JudgeQuestions.GetAll(null, null, "Questions");

            ApplicationObj = new Application();

            PitchObj = new Pitch();

            if (id != null)
            {
                ApplicationObj = _unitOfWork.Application.GetFirstOrDefault(u => u.ApplicantId == id);
            }

            PitchObj.ApplicationId = ApplicationObj.Id;
            PitchObj.Application = ApplicationObj;
            PitchObj.PitchDate = DateTime.Now;

            _unitOfWork.Pitch.Add(PitchObj);


            foreach (var judgeQuestion in JudgeQuestionsList)
            {
                JudgeScoresObj = new JudgeScores();

                JudgeScoresObj.JudgeQuestionsId = judgeQuestion.JudgeQuestionsId;
                JudgeScoresObj.Score = Int32.Parse(Request.Form[judgeQuestion.JudgeQuestionsId.ToString()]);
                JudgeScoresObj.Comment = Request.Form["comment-" + judgeQuestion.JudgeQuestionsId.ToString()];
                JudgeScoresObj.PitchId = PitchObj.PitchId;
                JudgeScoresObj.Pitch = PitchObj;

                _unitOfWork.JudgeScores.Add(JudgeScoresObj);

            }


            
            _unitOfWork.Save();
            return RedirectToPage("/Judge/PitchMeeting/PitchHistory/PitchHistoryDetails/Index", new { id = PitchObj.PitchId });
        }
    }
}
