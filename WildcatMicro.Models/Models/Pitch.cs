using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class Pitch
    {
        [Key]
        public int PitchId { get; set; }
        public DateTime PitchDate { get; set; }
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
    }
}
