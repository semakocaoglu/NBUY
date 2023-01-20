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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(EducationAppContext context) : base(context) 
        {
            
        }
        private EducationAppContext EducationAppContext
        {
            get { return _context as EducationAppContext; }
        }

       
        public async Task CreateTeacherAsync(Teacher teacher, int[] selectedCategoryIds)
        {
            await EducationAppContext.Teachers.AddAsync(teacher);
            await EducationAppContext.SaveChangesAsync();
            teacher.TeacherCategories = selectedCategoryIds
                .Select(catId => new TeacherCategory
                { 
                    TeacherId = teacher.Id,
                    CategoryId = catId
                }).ToList();
            await EducationAppContext.SaveChangesAsync();
        }

        public Task<Teacher> GetTeacherDetailsByUrlAsync(string teacherUrl)
        {
            return EducationAppContext
                 .Teachers
                 .Where(t => t.Url == teacherUrl)
                 .Include(t => t.TeacherCategories)
                 .ThenInclude(tc => tc.Category)
                 .FirstOrDefaultAsync();
        }

        public async Task<List<Teacher>> GetTeachersByCategoryAsync(string category)
        {
            var teachers = EducationAppContext.Teachers.AsQueryable();
            if(category != null)
            {
                teachers = teachers
                    .Include(t => t.TeacherCategories)
                    .ThenInclude(tc => tc.Category)
                    .Where(t => t.TeacherCategories.Any(tc => tc.Category.Url == category));
            }
            return await teachers.ToListAsync();
        }
    }
}
