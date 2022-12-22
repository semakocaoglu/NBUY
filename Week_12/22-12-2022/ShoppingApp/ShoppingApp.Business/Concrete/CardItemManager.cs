using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Business.Concrete
{
    public class CardItemManager : ICardItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task ChangeQuantity(int cardItemId, int quantity)
        {
            var cardItem = await _unitOfWork.CardItems.GetByIdAsync(cardItemId);
            await _unitOfWork.CardItems.ChangeQuantity(cardItem, quantity);
        }

        public void Delete(CardItem cardItem)
        {
            _unitOfWork.CardItems.Delete(cardItem);
            _unitOfWork.Save();
        }

        public async Task<CardItem> GetByIdAsync(int id)
        {
            return await _unitOfWork.CardItems.GetByIdAsync(id);
        }
    }
}