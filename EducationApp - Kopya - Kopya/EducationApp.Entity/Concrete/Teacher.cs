using EducationApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
    public class Teacher :IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LessonPlace { get; set; }
        public string Description { get; set; }
        public string EducationStatus { get; set; }
        public string Experience { get; set; }
        public decimal? Price { get; set; }
        public List<TeacherCategory> TeacherCategories { get; set; }
       
    }
}
