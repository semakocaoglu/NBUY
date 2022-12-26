﻿using Microsoft.EntityFrameworkCore;
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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopAppContext context) : base(context)
        {
            //buraya gelen context base classa gönderiliyor ve aynı zamanda sadece bu constructor içinde geçerli. Ama bu classın bütününde henüz kullanılamıyor. Eğer kullanılsın istersek yapmamız gereken işlemler var.
        }
        public Category GetByIdWithProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetSearchResultsAsync(string searchString)
        {

            searchString = searchString.ToLower();
            var result = ShopAppContext.Categories.AsQueryable();
           
            return await result.Where(c => c.Name.ToLower().Contains(searchString) || c.Description.ToLower().Contains(searchString)).ToListAsync();

        }
    }
}
