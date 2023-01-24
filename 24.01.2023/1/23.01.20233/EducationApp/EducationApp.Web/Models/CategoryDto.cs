using EducationApp.Entity.Concrete;

namespace EducationApp.Web.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? UpCatId { get; set; }
        public string Url { get; set; }
        public List<Category> SubCategory { get; set; }

    }
}
