using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrderDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrderDto orderdetail);

    }
}
