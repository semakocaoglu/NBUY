using EducationApp.Entity.Abstract;
using EducationApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
    public class Teacher : BaseUserEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EducationStatus { get; set; }
        public string Experience { get; set; }
        public decimal? Price { get; set; }
        public List<TeacherCategory> TeacherCategories { get; set; }
       
    }
}
