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

        //public async Task<List<Category>> GetSubCat(int id)
        //{
        //    return await EducationAppContext
        //        .Categories
        //        .Where(c => c.UpCatId >0)
        //        .Where(c => c.UpCatId == id )
        //        .ToListAsync();
                


        //}

        public Task<List<Category>> GetSubCat()
        {
            throw new NotImplementedException();
        }
    }
}
