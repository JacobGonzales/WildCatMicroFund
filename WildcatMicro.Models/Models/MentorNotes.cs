using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public  class MentorNotes
    {
        [Key]
        public int MentorNotesId { get; set; }
        public int  MentorAssignmentId { get; set; }
        [ForeignKey("MentorAssignmentId")]
        public virtual MentorAssignment MentorAssignment { get; set; }

        public DateTime MeetingDate { get; set; }
        public string Notes { get; set; }
    }
}
