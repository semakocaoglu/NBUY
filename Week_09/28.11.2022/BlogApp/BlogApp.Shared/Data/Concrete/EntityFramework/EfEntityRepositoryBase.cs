using BlogApp.Shared.Data.Abstract;
using BlogApp.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> 
        where TEntity : class, 
        IEntity,
        new()    
    {
        private readonly DbContext _context;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;   //Dependecny Injection
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await _context.Set<TEntity>().AnyAsync(predicate); 
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });  //Task.Run:asenkron olmasını sağlar
        }

        public async Task UpDateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            //Burada conteximize erişip, hangi entity ile çalşacaksak o entityi IQuarable tipinde alıypruz.Ki sonra bunun arkasına Where, Include gibi yapıları duruma göre ekleyebilelim
            IQueryable<TEntity> query = _context.Set<TEntity>();
            
            //Bu metoda gelen birinci parametre yeni predicate eğer null değilse, bu bir koşul belirtilmiş demketir. Dolayısıyla bu durumda o koşulu(predicate) if içinde Where ile query üzerine ekliyorum. Eğer predicate null ise query üzerine Where ile ilgili bir şey eklememize gerek yok! 
           if(predicate != null)
            {
                query = query.Where(predicate);
            }

           //Eğer 2.parametremiz olan incluProperties dizisinde eleman varsa, bu diziiçinde dönerek her elemanı query'e ekliyoruz. Ki her eleman bir Include taşıyor. Burası da bittiğinde artık ToList yapılabilir halde bir query elimizde olacak.
           if(includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

           //Artık ToListAsync yapılabilecek query elimizde. Biz de geriye döndüreceğimiz query'i ToListAsync ile listeye çeviriyoruz çünkü bu metod geriye bir liste döndürmeli.
           return await query.ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query =_context.Set<TEntity>();
            query=query.Where(predicate);
            if(includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); 
                }
            }
            return await query.FirstOrDefaultAsync(); //ilk karşılaştığını getirir.Ya da
            //return await query.SingleOrDefaultAsync();
        }

       
    }
}








