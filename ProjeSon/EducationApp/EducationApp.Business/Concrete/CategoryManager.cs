﻿using EducationApp.Business.Abstract;
using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete;
using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitfOfWork;
        public CategoryManager(IUnitOfWork unitfOfWork)
        {
            _unitfOfWork = unitfOfWork;
        }
    
        public async Task CreateAsync(Category category)
        {
            await _unitfOfWork.Categories.CreateAsync(category);
            await _unitfOfWork.SaveAsync();
            
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _unitfOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _unitfOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoriesByStudent(Student student)
        {
            return await _unitfOfWork.Categories.GetCategoriesByStudent(student);
        }

        public async Task<List<Category>> GetCategoriesByTeacher(Teacher teacher)
        {
            return await _unitfOfWork.Categories.GetCategoriesByTeacher(teacher);
        }

        public async Task<List<Category>> GetHomePageCategoriesAsync()
        {
            return await _unitfOfWork.Categories.GetHomePageCategoriesAsync();
        }

        public async Task<List<Category>> GetSubCat(int id)
        {
            return await _unitfOfWork.Categories.GetSubCat(id);
        }

        public async Task<List<Category>> GetSubCat()
        {
            return await _unitfOfWork.Categories.GetSubCat();
        }

        public async Task<List<Category>> GetUpCat()
        {
            return await _unitfOfWork.Categories.GetUpCat();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePopularCategory(Category category)
        {
            
            await _unitfOfWork.Categories.UpdatePopularCategory(category);
        }
    }
}
