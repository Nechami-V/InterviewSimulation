using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace subWebTemech.Models
{
    public class CategoryProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CategorySubCategoryId")]
        public int CategorySubCategoryId { get; set; }

        [ForeignKey("UserProfileID")]
        public int UserProfileID { get; set; }

        public virtual CategorySubCategory CategorySubCategory { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        

    }
}
