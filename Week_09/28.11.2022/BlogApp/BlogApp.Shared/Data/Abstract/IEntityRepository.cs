using BlogApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Data.Abstract
{
    public interface IEntityRepository<T> 
        where T: class , 
        IEntity, 
        new()    //Buraya gönderilecek olan T'nin özellikleridir.T'nin kısıtları, bizim hata yapmamızı engeller.

    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //Not-1 Not-2

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties); //Not-3

        Task AddAsync(T entity);    //Geri döndürmediği için sadece Task
        Task UpDateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>>predicate); //Böyle bir user var mı mesela?
        Task<int> CountAsync(Expression<Func<T, bool>>predicate); //Kategorisi 1 olanların sayısı mesela


    }
}

/*
 * Not-1
 * ********
 * Örneğin Id'si 12 olan kaydı getirmek istiyoruz.
 * var article = repository.GetAsync(x=>x.Id==12);
 * User user = repositoryUser.GetAsync(x=>x.Name == "enginniyazi")
 * 
 * Not-2
 * **********
 * Örneğin Id'si 12 olan Article'ı User ve Comment'leriyle birlikte getirmek istiyoruz.
 * Article article = repositoryArticle.GetAsync(x=>x.Id == 12, y=>y.User , y=>y.Comments, z=>z.Role)
 * 
 * Not-3
 * ********
 * Örneğin tüm Article'ları listelemek istiyoruz
 * var articles= repositoryArticle.GetAllAsync();
 * Örneğin DotNet Category'sindeki tüm Articlerı listelemek istiyoruz
 * var articles = repositoryArticle.GetAllAsync(a=>a.CategoryName == "DotNet" , c=>c.Category)
 * Örneğin Id'si 12 olan Article'ın yorumlarını getirmek istiyoruz.
 * var comments= repositoryComment.GetAllAsync(c=>c.ArticleId==12)
 * 
 * 
 * 
 * 
 */
