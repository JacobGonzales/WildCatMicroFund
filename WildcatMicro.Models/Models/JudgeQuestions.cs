using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WildcatMicro.Models
{
    public class JudgeQuestions
    {
        [Key]
        public int JudgeQuestionsId { get; set; }
        public float Weight { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Questions Questions { get; set; }

    }
}
