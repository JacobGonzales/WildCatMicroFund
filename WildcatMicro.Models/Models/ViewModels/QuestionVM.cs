using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.Models.ViewModels
{
    public class QuestionVM
    {
        public Questions Question { get; set; }
        public IEnumerable<SelectListItem> QuestionCategory { get; set; }
    }
}
