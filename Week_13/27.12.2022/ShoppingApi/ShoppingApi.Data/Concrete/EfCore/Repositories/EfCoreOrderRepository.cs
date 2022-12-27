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
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ShopAppContext context) : base(context)
        {

        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }
        public async Task<List<Order>> GetOrders(string userId = null)
        {
            #region UserIdNullKontrolüYapılmadan
            //var orders = ShopAppContext.Orders
            //    .Where(o => o.UserId == userId)
            //    .Include(o=>o.OrderItems)
            //    .ThenInclude(od=>od.Product)
            //    .ToList();
            //return orders;
            #endregion
            
            #region UserIdNullKontrolüYaparak
            var orders = ShopAppContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .AsQueryable();
            if (!String.IsNullOrEmpty(userId))
            {
                orders = orders.Where(o => o.UserId == userId);
            }
            return orders.ToList();
            #endregion
        }
    }
}
