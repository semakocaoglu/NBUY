using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task<List<Student>> GetStudentsByCategoryAsync (string category);
        Task<Student> GetStudentDetailsByUrlAsync(string studentUrl);
        Task<List<Student>> GetAllStudentsWithCategory();
        Task CreateStudentAsync(Student student, int[] selectedCategoryIds);
       


    }
}
