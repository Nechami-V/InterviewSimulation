using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace subWebTemech.Models
{
    public class JobSubCategory
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Job")]
        public int jobId { get; set; }

        [ForeignKey("CategorySubCategory")]
        public int categorySubCategoryId { get; set; }

        public virtual CategorySubCategory CategorySubCategory { get; set; }
        public virtual Job Job { get; set; }
    }
}
