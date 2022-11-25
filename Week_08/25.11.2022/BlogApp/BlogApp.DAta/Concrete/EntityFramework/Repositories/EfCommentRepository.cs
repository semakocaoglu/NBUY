using BlogApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EntityFramework.Repositories
{
    public interface EfCommentRepository : EfEntityRepositoryBase<Comment>
    {
        public EfCommentRepository(DbContext context)
    }
}
