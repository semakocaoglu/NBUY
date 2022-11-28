﻿using BlogApp.Entities.Concrete;
using BlogApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EntityFramework.Repositories
{
    public interface EfCategoryRepository :EfEntityRepositoryBase<Category>
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {

        }

    }
}
