using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace subWebTemech.Models
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }

        [ForeignKey("UserProfileID")]
        public int UserProfileID { get; set; }
        public string ExperienceLevel { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
      
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<JobSubCategory> JobSubCategorys { get; set; }


    }
}
