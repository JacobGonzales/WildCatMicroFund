using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }
        
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser {get; set;}      

    }
}
