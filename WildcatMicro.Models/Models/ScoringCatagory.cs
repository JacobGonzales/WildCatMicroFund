using System.ComponentModel.DataAnnotations;

namespace WildcatMicro.Models
{
    public class ScoringCatagory
    {
        [Key]
        public int ScoringCatagoryId { get; set; }

        public string Description { get; set; }
    }
}