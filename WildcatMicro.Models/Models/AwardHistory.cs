using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WildcatMicro.Models.Models;

namespace WildcatMicro.Models
{
   public class AwardHistory
    {
        [Key]
        public int AwardHistoryId { get; set; }
        public DateTime AwardDate { get; set; }
        public float Amount { get; set; }
        public string Agreement { get; set; }
        public int ReqNumber { get; set; }
        public DateTime MailDate { get; set; }
        public string Provider { get; set; }
        public string AwardType { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

    }
}
