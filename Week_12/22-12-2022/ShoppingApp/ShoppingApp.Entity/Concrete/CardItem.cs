using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Abstract;

namespace ShoppingApp.Entity.Concrete
{
    public class CardItem : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Quantity { get; set; }
    }
}