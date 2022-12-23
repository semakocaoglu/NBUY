using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task AddToCard(string userId, int productId, int quantity)
        {
            await _unitOfWork.Cards.AddToCard(userId, productId, quantity);
            //await _unitOfWork.SaveAsync();
        }

        public async Task InitializeCard(string userId)
        {
            await _unitOfWork.Cards.CreateAsync(new Card { UserId= userId });
            await _unitOfWork.SaveAsync();
        }
        public async Task<Card>GetByIdAsync(int id)
        {
            return await _unitOfWork.Cards.GetByIdAsync(id);
        }

        public async Task<Card> GetCardByUserId(string userId)
        {
            return await _unitOfWork.Cards.GetCardByUserId(userId);
        }

        
    }
}
