using subWebTemech.Models;

namespace subWebTemech.DTOs
{
    public class CategoryDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<CategorySubCategory> categorySubCategorys { get; set; }

    }
}
