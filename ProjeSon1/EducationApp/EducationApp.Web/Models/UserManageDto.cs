using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationApp.Web.Models
{
    public class UserManageDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string LessonPlace { get; set; }
        public string EducationStatus { get; set; }
        public string Experience { get; set; }
        public decimal? Price { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int[] SelectedCategoryIds { get; set; }
        public string Role { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> ExperienceList { get; set; }
        public List<SelectListItem> LessonPlaceList { get; set; }
        public List<Category> Categories { get; set; }
      
    }
}
