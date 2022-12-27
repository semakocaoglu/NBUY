﻿using ShoppinApi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinApi.Business.Abstract
{
    public interface ICardService
    {
        Task InitializeCard(string userId);
        Task AddToCard(string userId, int productId, int quantity);
        Task<Card> GetByIdAsync(int id);
        Task<Card> GetCardByUserId(string userId);
    }
}