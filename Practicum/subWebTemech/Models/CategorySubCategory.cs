using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class CategorySubCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<CategoryProfile> CategoryProfile { get; set; }
        public virtual ICollection<JobSubCategory> JobSubCategorys { get; set; }

    }
}
