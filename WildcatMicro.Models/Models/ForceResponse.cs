using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class ForceResponse
    {
        [Key]
        public int ForceResponseId { get; set; }
        public int QuestionId { get; set; }
        
        [ForeignKey("QuestionId")]     
        public string Response { get; set; }

    }
}
