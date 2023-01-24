using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Abstract
{
    public interface ITeacherRepository :IRepository<Teacher>
    {
        Task<List<Teacher>> GetTeachersByCategoryAsync(string category);
        Task<Teacher> GetTeacherDetailsByUrlAsync(string teacherUrl);
        Task CreateTeacherAsync(Teacher product, int[] selectedCategoryIds);
        Task<List<Teacher>> GetAllTeachersWithCategory();
        Task<Teacher> GetTeacherWithCategories(int id);
        Task UpdateTeacherAsync(Teacher teacher, int[] selectedCategoryIds);

    }
}
