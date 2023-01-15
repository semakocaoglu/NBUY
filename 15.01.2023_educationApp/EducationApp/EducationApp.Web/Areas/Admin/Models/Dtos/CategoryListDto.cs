using EducationApp.Entity.Concrete;

namespace EducationApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryListDto
    {
        public List<Category> Categories { get; set; }
        public List<Category> SubCategory { get; set; }
        public List<Category> UpCategory { get; set; }
    }
}
