using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
    public class StudentCategory
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }





    }
}
