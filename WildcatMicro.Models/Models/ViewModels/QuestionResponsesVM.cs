using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.ViewModels
{
    public class QuestionResponsesVM
    {
        public QuestionResponses Responses { get; set; }
        public IEnumerable<SelectListItem> QuestionsList { get; set; }
        public IEnumerable<SelectListItem> ApplicationList { get; set; }
    }
}

