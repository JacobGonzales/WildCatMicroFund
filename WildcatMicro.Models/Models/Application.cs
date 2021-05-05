using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int StatusId{ get; set; }
        [ForeignKey("StatusId")]
        public virtual Statuses Statuses { get; set; }

        public string ApplicationStatusDescription { get; set; }

        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }
      
    }
}
