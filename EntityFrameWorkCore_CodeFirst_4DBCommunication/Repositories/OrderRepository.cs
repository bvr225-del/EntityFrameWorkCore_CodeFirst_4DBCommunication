using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Order;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public async Task<int> AddOrder(Order orderdetail)
        {
            await _orderContext.Orders123.AddAsync(orderdetail);
            _orderContext.SaveChanges();
            return 1;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            var result = await _orderContext.Orders123.Where(e => e.orderid == orderid).FirstOrDefaultAsync();
            if (result != null)
            {//Here Remove() method is used for removing the data from database.
                _orderContext.Orders123.Remove(result);
                _orderContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<Order> GetOrderById(int orderid)
        {
            var result = await _orderContext.Orders123.Where(e => e.orderid == orderid).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<List<Order>> GetOrders()
        {
            var result = _orderContext.Orders123.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateOrder(Order orderdetail)
        {
            _orderContext.Orders123.Update(orderdetail);
            await _orderContext.SaveChangesAsync();
            return true;

        }

    }
}
