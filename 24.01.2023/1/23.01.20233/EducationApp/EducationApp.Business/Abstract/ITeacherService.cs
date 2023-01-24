using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task<List<Teacher>> GetTeachersByCategoryAsync(string category);
        Task<Teacher> GetTeacherDetailsByUrlAsync(string teacherUrl);
        Task CreateTeacherAsync(Teacher teacher, int[] selectedCategoryIds);
        Task<List<Teacher>> GetAllTeachersWithCategory();
        Task CreateAsync(Teacher teacher);
        Task<Teacher> GetTeacherWithCategories(int id);
    }
}
