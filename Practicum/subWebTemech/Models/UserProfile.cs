using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using subWebTemech.Models;

namespace subWebTemech.Models
{
    public class UserProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProfileID { get; set; }
        public int UserID { get; set; }
        public string ExperienceLevel { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<CategoryProfile> CategoryProfiles{ get; set; }
    }
}
