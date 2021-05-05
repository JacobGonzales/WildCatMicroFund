using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class MentorAssignment
    {
        [Key]
        public int MentorAssignmentId { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime ApprovedToPitchDate { get; set; }


        // relation ship
        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }


        //Mentor
        public string ApplicationUserId { get; set; }

        public bool enabled { get; set; }

    }
}
