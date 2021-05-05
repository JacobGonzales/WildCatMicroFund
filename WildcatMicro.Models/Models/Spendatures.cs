using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WildcatMicro.Models.Models
{
    public class Spendatures
    {
        [Key]
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }

        public int AwardHistoryId { get; set; }
        [ForeignKey("AwardHistoryId")]
        public virtual AwardHistory AwardHistory { get; set; }
    }
}
