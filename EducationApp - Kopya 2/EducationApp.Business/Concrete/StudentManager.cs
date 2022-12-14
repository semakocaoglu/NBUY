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

        public async Task<List<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

      

        public Task<Student> GetStudentDetailsByUrlAsync(string studentUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetStudentsByCategoryAsync(string category)
        {
            return await _unitOfWork.Students.GetStudentsByCategoryAsync(category);
        }
    }
}
