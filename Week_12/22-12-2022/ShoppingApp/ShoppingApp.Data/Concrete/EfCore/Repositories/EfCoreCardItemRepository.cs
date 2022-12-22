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
    public class EfCoreCardItemRepository : EfCoreGenericRepository<CardItem>, ICardItemRepository
    {
        public EfCoreCardItemRepository(ShopAppContext context) : base(context)
        {
        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }
        public async Task ChangeQuantity(CardItem cardItem, int quantity)
        {
            cardItem.Quantity = quantity;
            ShopAppContext.CardItems.Update(cardItem);
            await ShopAppContext.SaveChangesAsync();
        }
    }
}