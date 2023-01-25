using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete.EfCore.Contexts;
using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(DbContext context) : base(context)
        {
        }
        private EducationAppContext EducationAppContext
        {
            get { return _context as EducationAppContext;  }
        }

        public async Task<List<Category>> GetUpCat()
        {
          
            return await EducationAppContext
                .Categories
                .Where(c => c.UpCatId ==0)
                .ToListAsync();
          
            
        }

        public async Task<List<Category>> GetSubCat(int id)
        {
            return await EducationAppContext
                .Categories
                .Where(c => c.UpCatId == id)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByStudent(Student student)
        {
            int[] categoryIds = await EducationAppContext.StudentCategories.Where(sc => sc.StudentId == student.Id).Select(sc => sc.CategoryId).ToArrayAsync();
            List<Category> categories = await EducationAppContext.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
            return categories;
        }

        public async Task<List<Category>> GetCategoriesByTeacher(Teacher teacher)
        {
            int[] categoryIds = await EducationAppContext.TeacherCategories.Where(sc => sc.TeacherId == teacher.Id).Select(sc => sc.CategoryId).ToArrayAsync();
            List<Category> categories = await EducationAppContext.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
            return categories;
        }

        public async Task<List<Category>> GetSubCat()
        {
            return await EducationAppContext
                .Categories
                .Where(c => c.UpCatId != 0)
                .ToListAsync();
        }

        public async Task<List<Category>> GetHomePageCategoriesAsync()
        {
            return await EducationAppContext
                .Categories
                .Where(c => c.PopularCategory)
                .ToListAsync();
        }
    }
}
