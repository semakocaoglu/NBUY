using Microsoft.EntityFrameworkCore;
using ShoppinApi.Data.Abstract;
using ShoppinApi.Data.Concrete.EfCore.Contexts;
using ShoppinApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinApi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCardItemRepository : EfCoreGenericRepository<CardItem>, ICardItemRepository
    {
        public EfCoreCardItemRepository(ShopAppContext context):base(context)
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
        }

        public void ClearCard(int cardId)
        {
            ShopAppContext
                .CardItems
                .Where(ci => ci.CardId == cardId)
                .ExecuteDelete();
        }
    }
}
