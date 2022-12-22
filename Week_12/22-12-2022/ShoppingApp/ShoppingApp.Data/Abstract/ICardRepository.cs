using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Data.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        Task AddToCard(string userId, int productId, int quantity);
        Task<Card> GetCardByUserIdAsync(string userId);

    }
}