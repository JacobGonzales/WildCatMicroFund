using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class QuestionResponses
    {
        [Key]
        public int ResponseId { get; set; }

        public int QuestionsId { get; set; }
        [ForeignKey("QuestionsId")]
        public virtual Questions Questions { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
        
        public DateTime ResponseDate { get; set; }

        public string Response { get; set; }

        

    }
}
