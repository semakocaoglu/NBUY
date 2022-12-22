using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCardRepository : EfCoreGenericRepository<Card>, ICardRepository
    {
        public EfCoreCardRepository(DbContext context) : base(context)
        {
        }

        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }

        public async Task AddToCard(string userId, int productId, int quantity)
        {
            var card = await GetCardByUserIdAsync(userId);
            if (card != null)
            {
                var index = card.CardItems.FindIndex(ci => ci.ProductId == productId);
                if (index == -1)
                {
                    card.CardItems.Add(new CardItem
                    {
                        CardId = card.Id,
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
                else
                {
                    card.CardItems[index].Quantity += quantity;
                }

                ShopAppContext.Cards.Update(card);
                await ShopAppContext.SaveChangesAsync();
            }
        }

        public async Task<Card> GetCardByUserIdAsync(string userId)
        {
            var card = await ShopAppContext.Cards.Include(c => c.CardItems).ThenInclude(ci => ci.Product).FirstOrDefaultAsync(c => c.UserId == userId);

            return card;
        }
    }
}