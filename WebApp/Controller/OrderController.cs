using Domain;
using Infrastructure;
using Infrastructure.DataContext;
using Infrastructure.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Order>>> GetOrders()
    {
            var orders = await service.GetOrders();
            return orders;
    }

    [HttpPost]
    public async Task<Response<bool>> PostOrders(Order order)
    {
              var result = await service.AddOrder(order);
            return result;

    }

    [HttpPut("status/{orderId}")]
    public async Task<Response<bool>> UpdateOrderStatus(int orderId,string newstatus)
    {
    
            var res = service.UpdateOrder(orderId, newstatus);
            return await res;
    
    }
    
}