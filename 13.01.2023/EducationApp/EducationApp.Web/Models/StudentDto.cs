
using EducationApp.Entity.Concrete;

namespace EducationApp.Web.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string LessonPlace { get; set; }
        public List<Category> Categories { get; set; }



    }
}
