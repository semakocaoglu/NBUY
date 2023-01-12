using EducationApp.Entity.Abstract;
using EducationApp.Entity.Concrete.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
    public class Student : BaseUserEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public List<StudentCategory> StudentCategories { get; set; }
    }
}
