using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuestionCategoryId { get; set; }
        [ForeignKey("QuestionCategoryId")]
        public virtual QuestionCategorys QuestionCategorys { get; set; }        
        public string Question { get; set; }

        public int Order { get; set; }

        public string Type { get; set; }


    }
}
