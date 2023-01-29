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
    public class StudentManager : IStudentService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public StudentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     

        public async Task CreateStudentAsync(Student student, int[] selectedCategoryIds)
        {
            await _unitOfWork.Students.CreateStudentAsync(student, selectedCategoryIds);
        }

        public void Delete(Student student)
        {
            _unitOfWork.Students.Delete(student);
            _unitOfWork.Save();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<List<Student>> GetAllStudentsWithCategory()
        {
            return await _unitOfWork.Students.GetAllStudentsWithCategory();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        

        public async Task<Student> GetStudentDetailsByUrlAsync(string studentUrl)
        {
            return await _unitOfWork.Students.GetStudentDetailsByUrlAsync(studentUrl);
          
        }

        public async Task<List<Student>> GetStudentsByCategoryAsync(string category)
        {
            return await _unitOfWork.Students.GetStudentsByCategoryAsync(category);
        }

        public async Task<Student> GetStudentWithCategories(int id)
        {
            return await _unitOfWork.Students.GetStudentWithCategories(id);
        }

        public async Task UpdateStudentAsync(Student student, int[] selectedCategoryIds)
        {
            await _unitOfWork.Students.UpdateStudentAsync(student, selectedCategoryIds);
        }
    }
}
