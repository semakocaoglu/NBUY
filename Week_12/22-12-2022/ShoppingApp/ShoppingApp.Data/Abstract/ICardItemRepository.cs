using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Data.Abstract
{
    public interface ICardItemRepository : IRepository<CardItem>
    {
        Task ChangeQuantity(CardItem cardItem, int quantity);
    }
}