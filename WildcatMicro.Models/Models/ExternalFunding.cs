using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class ExternalFunding
    {
        [Key]
        public int ExternalFundingId { get; set; }  // need primary key  ?

        public float Amount { get; set; }
        public string Source { get; set; }

        public DateTime  Date { get; set; }
        // relation ship
        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

    }
}
