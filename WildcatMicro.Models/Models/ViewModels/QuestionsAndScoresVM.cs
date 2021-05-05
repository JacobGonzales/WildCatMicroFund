using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.ViewModels
{
    public class QuestionsAndScoresVM
    {
        public IEnumerable<JudgeScores> JudgeScoresList { get; set; }
        public IEnumerable<JudgeQuestions> JudgeQuestionsList { get; set; }
    }
}
