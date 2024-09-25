using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace subWebTemech.Models
{
    public class JobSudmitted
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int jobID { get; set; }
        public virtual User userId { get; set; }
        //public virtual Job jobId { get; set; }
    }
}
