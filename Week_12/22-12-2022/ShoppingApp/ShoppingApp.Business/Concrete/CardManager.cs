using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToCard(string userId, int productId, int quantity)
        {
            await _unitOfWork.Cards.AddToCard(userId, productId, quantity);
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _unitOfWork.Cards.GetByIdAsync(id);
        }

        public async Task<Card> GetCardByUserIdAsync(string userId)
        {
            return await _unitOfWork.Cards.GetCardByUserIdAsync(userId);
        }

        public async Task InitializeCard(string userId)
        {
            await _unitOfWork.Cards.CreateAsync(new Card { UserId = userId });
            await _unitOfWork.SaveAsync();
        }
    }
}