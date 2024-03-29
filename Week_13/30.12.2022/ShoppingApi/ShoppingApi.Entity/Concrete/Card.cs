﻿using ShoppingApi.Entity.Abstract;
using ShoppingApi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApi.Entity.Concrete
{
    public class Card : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CardItem> CardItems { get; set; }
    }
}
