using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Abstract;
using ShoppingApp.Entity.Concrete.Identity;

namespace ShoppingApp.Entity.Concrete
{
    public class Card : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CardItem> CardItems { get; set; }
    }
}