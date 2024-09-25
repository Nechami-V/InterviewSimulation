using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class JobType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
     


    }
}
