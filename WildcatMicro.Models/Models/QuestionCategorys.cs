using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class QuestionCategorys
    {
        [Key]
        public int QuestionCategoryId { get; set; }            
        public string Category { get; set; }

    }
}
