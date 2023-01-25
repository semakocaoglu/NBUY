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
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(DbContext context) : base(context)
        {
        }

        private EducationAppContext EducationAppContext
        {
            get { return _context as EducationAppContext; }
        }

        public async Task CreateStudentAsync(Student student, int[] selectedCategoryIds)
        {
            await EducationAppContext.Students.AddAsync(student);
            await EducationAppContext.SaveChangesAsync();
            student.StudentCategories = selectedCategoryIds
                .Select(catId => new StudentCategory
                {
                    StudentId = student.Id,
                    CategoryId = catId
                }).ToList();
            await EducationAppContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentsWithCategory()
        {
            var students = await EducationAppContext
                .Students
                .Include(s => s.StudentCategories)
                .ThenInclude(sc => sc.Category)
                .ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByUserId(string userId)
        {
            return await EducationAppContext.Students.Include(t => t.StudentCategories).ThenInclude(tc => tc.Category).Where(s => s.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentDetailsByUrlAsync(string studentUrl)
        {
            return await EducationAppContext
                .Students
                .Where(s => s.Url == studentUrl)
                .Include(s => s.StudentCategories)
                .ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudentsByCategoryAsync(string category)
        {
            var students = EducationAppContext.Students.AsQueryable();
            if (category != null)
            {
                students = students
                    .Include(s => s.StudentCategories)
                    .ThenInclude(sc => sc.Category)
                    .Where(s => s.StudentCategories.Any(sc => sc.Category.Url == category));
            }
            return await students.ToListAsync();
        }
    }
}
