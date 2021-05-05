using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicro.Models.Models.ViewModels
{
    public class MentorAssignmentsNotesVM
    {
        public MentorAssignment MentorAssignment { get; set; }
        public List<MentorNotes> MentorNotes { get; set; }

    }
}


