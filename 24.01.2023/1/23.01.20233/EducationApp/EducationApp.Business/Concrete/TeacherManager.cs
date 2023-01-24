using EducationApp.Business.Abstract;
using EducationApp.Data.Abstract;
using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeacherManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _unitOfWork.Teachers.CreateAsync(teacher);
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateTeacherAsync(Teacher teacher, int[] selectedCategoryIds)
        {
            await _unitOfWork.Teachers.CreateTeacherAsync(teacher, selectedCategoryIds);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersWithCategory()
        {
            return await _unitOfWork.Teachers.GetAllTeachersWithCategory();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(id); 
        }

        public Task<Teacher> GetWithCategories(int id)
        {
            return await _unitOfWork.Teachers.GetTeacherWithCategories(id);
        }

        public Task<Teacher> GetTeacherDetailsByUrlAsync(string teacherUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Teacher>> GetTeachersByCategoryAsync(string category)
        {
            return await _unitOfWork.Teachers.GetTeachersByCategoryAsync(category);
        }

        
    }
}
