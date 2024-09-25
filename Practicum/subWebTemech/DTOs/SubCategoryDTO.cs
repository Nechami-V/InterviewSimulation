using subWebTemech.Models;

namespace subWebTemech.DTOs
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategorySubCategory> CategorySubCategorys { get; set; }
}
}
