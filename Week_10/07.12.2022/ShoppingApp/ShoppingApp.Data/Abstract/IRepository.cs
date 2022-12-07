using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IRepository<T>

    {
        Task<T> GetByIdAsync(int id); //id'ye göre entity getirecek
        Task<List<T>> GetAllAsync(); //İlgili entity ile ilgili tüm kayıtları getirecek.
        Task CreateAsync(T Entity); //yeni kayıt yaratacak
        void Update(T Entity); // Kayıt güncellenecek
        void Delete(T Entity); // Kayıt silecek


    }
}
