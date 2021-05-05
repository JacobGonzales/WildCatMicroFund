using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.Pages.Judge.PitchMeeting.PitchHistory.PitchHistoryDetails
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<JudgeScores> JudgeScoresList { get; set; }
        
        public IEnumerable<Models.JudgeQuestions> JudgeQuestionsList { get; set; }

        public Pitch PitchObj { get; set; }

        public float finalScore = 0;

        float weightTotal = 0;

        public void OnGet(int? id)
        {
            var scores = _unitOfWork.JudgeScores.GetAll(null, s => s.OrderBy(t => t.JudgeQuestions.Questions), "JudgeQuestions").Where(p => p.PitchId == id);

            var questions = _unitOfWork.JudgeQuestions.GetAll(null, s => s.OrderBy(t => t.Questions), "Questions");

            JudgeScoresList = scores;
            JudgeQuestionsList = questions;

            PitchObj = _unitOfWork.Pitch.GetFirstOrDefault(p => p.PitchId == id, "Application");

            foreach (var question in JudgeQuestionsList)
            {
                weightTotal += question.Weight;

            }

            foreach (var question in JudgeQuestionsList)
            {
                foreach (var score in JudgeScoresList.Where(s => s.JudgeQuestionsId == question.JudgeQuestionsId))
                {
                    float currentWeight = question.Weight;
                    float currentScore = score.Score;
                    finalScore += (currentWeight * currentScore);
                }
            }
            finalScore = (finalScore / weightTotal) * 10;
            finalScore = (float)Math.Round(finalScore, 1);
        }
    }
}
