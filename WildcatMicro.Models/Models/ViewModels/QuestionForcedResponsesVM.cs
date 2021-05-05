using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.Models.ViewModels
{
    public class QuestionForcedResponsesVM
    {
        public Questions Question { get; set; }
        public List<ForceResponse> Responses { get; set; }

        public IEnumerable<SelectListItem> ResponseList { get; set; }
    }
}


