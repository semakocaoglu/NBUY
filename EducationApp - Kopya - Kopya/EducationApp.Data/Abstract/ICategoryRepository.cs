using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetUpCat();
        Task<List<Category>> GetSubCat();
    }
}
