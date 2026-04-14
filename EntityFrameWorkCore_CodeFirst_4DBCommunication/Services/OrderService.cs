using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Order;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository=orderRepository;
        }
        public async Task<int> AddOrder(OrderDto orderdetail)
        {
            Order order = new Order();
            order.orderid = orderdetail.orderid;
            order.ordername = orderdetail.ordername;
            order.orderlocation = orderdetail.orderlocation;
            var res = await _orderRepository.AddOrder(order);
            return res;

        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _orderRepository.DeleteOrderById(orderid);
            return true;

        }

        public async Task<OrderDto> GetOrderById(int orderid)
        {
            var res = await _orderRepository.GetOrderById(orderid);
            OrderDto orderdto = new OrderDto();
            orderdto.orderid = res.orderid;
            orderdto.ordername = res.ordername;
            orderdto.orderlocation = res.orderlocation;
            return orderdto;

        }

        public async Task<List<OrderDto>> GetOrders()
        {
            List<OrderDto> lstorderdto = new List<OrderDto>();
            var res = await _orderRepository.GetOrders();
            foreach (Order order in res)
            {
                OrderDto OrderDto = new OrderDto();
                OrderDto.orderid = order.orderid;
                OrderDto.ordername = order.ordername;
                OrderDto.orderlocation = order.orderlocation;
                lstorderdto.Add(OrderDto);//Add the orders to list here

            }
            return lstorderdto;

        }

        public async Task<bool> UpdateOrder(OrderDto orderdetail)
        {
            Order obj = new Order();
            obj.orderid = orderdetail.orderid;
            obj.ordername = orderdetail.ordername;
            obj.orderlocation = orderdetail.orderlocation;
            await _orderRepository.UpdateOrder(obj);
            return true;

        }
    }
}
