using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicro.Models
{
    public class Statuses
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }


    }
}
