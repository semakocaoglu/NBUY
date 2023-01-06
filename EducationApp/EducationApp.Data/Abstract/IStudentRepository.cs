using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetTeachersByCategoryAsync(string category);
        Task<Student> GetTeacherDetailsByUrlAsync(string studentUrl);
    }
}
