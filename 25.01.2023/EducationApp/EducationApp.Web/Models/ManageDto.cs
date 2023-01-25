using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.Identity;

namespace EducationApp.Web.Models
{
    public class ManageDto
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public User User { get; set; }
        public int[] SelectedCategoryIds { get; set; }
        public List<Category> Categories { get; set; }

    }
}
