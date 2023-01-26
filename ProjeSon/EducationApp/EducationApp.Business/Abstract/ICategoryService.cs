using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<List<Category>> GetUpCat();
        Task<List<Category>> GetSubCat(int id);
        Task<List<Category>> GetSubCat();
        Task<List<Category>> GetCategoriesByStudent(Student student);
        Task<List<Category>> GetCategoriesByTeacher(Teacher teacher);
        Task<List<Category>> GetHomePageCategoriesAsync();
        Task UpdatePopularCategory(Category category);

    }
}
