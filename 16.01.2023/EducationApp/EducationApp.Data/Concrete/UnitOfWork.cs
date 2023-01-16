using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete.EfCore.Contexts;
using EducationApp.Data.Concrete.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationAppContext _context;

        public UnitOfWork(EducationAppContext context)
        {
            _context = context;
        }

        private EfCoreStudentRepository _studentRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreTeacherRepository _teacherRepository;
        public IStudentRepository Students => _studentRepository = _studentRepository ?? new EfCoreStudentRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);
        public ITeacherRepository Teachers => _teacherRepository = _teacherRepository ?? new EfCoreTeacherRepository(_context);

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
