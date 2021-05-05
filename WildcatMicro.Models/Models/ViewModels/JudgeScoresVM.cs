using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.ViewModels
{
    public class JudgeQuestionsVM
    {
        public JudgeQuestions JudgeQuestions { get; set; }
        public IEnumerable<SelectListItem> Questions { get; set; }
    }
}
