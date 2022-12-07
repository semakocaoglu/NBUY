using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(ShopAppContext context) : base(context)
        {


        }
        private ShopAppContext shopAppContext
        {
            get { return _context as ShopAppContext; }

        }

        public async List<Product> GetHomePageProductsAsync()
        {
           return await shopAppContext
                .Products
                .Where(p=>p.IsHome && )
        }
        

        public List<Product> GetProductsByCategory()
        {
            throw new NotImplementedException();
        }
    }
}
