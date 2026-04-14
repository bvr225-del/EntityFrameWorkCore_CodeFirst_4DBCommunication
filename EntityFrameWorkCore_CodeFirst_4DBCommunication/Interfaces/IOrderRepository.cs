using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Order;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int orderid);
        Task<int> AddOrder(Order orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Order orderdetail);

    }
}
