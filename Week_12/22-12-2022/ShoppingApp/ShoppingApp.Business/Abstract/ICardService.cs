using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Business.Abstract
{
    public interface ICardService
    {
        Task InitializeCard(string userId);
        Task<Card> GetByIdAsync(int id);
        Task<Card> GetCardByUserIdAsync(string userId);
        Task AddToCard(string userId, int productId, int quantity);
    }
}