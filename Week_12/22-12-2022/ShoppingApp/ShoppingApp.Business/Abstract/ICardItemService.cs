using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Business.Abstract
{
    public interface ICardItemService
    {
        Task<CardItem> GetByIdAsync(int id);
        Task ChangeQuantity(int cardItemId, int quantity);
        void Delete(CardItem cardItem);

    }
}