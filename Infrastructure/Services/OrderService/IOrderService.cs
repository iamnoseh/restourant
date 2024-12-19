using Domain;

namespace Infrastructure.OrderService;

public interface IOrderService
{
    Task<Response<List<Order>>> GetOrders();
    Task<Response<bool>> AddOrder(Order order);
    Task<Response<bool>> UpdateOrder(int id,string status);
}