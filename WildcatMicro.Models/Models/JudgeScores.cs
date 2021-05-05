using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WildcatMicro.Models
{
    public class JudgeScores
    {
        [Key]
        public int JudgeScoresId { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
        public int JudgeQuestionsId { get; set; }

        [ForeignKey("JudgeQuestionsId")]
        public virtual JudgeQuestions JudgeQuestions { get; set; }
        public int PitchId { get; set; }

        [ForeignKey("PitchId")]
        public virtual Pitch Pitch { get; set; }
    }
}
