using System.Net;
using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.OrderService;

public class OrderService(DapperContext context):IOrderService
{
    public async Task<Response<List<Order>>> GetOrders()
    {
        try
        {
            string sql = "select * from orders";
            using var _context = context.GetConnection();
            var effect = await _context.QueryAsync<Order>(sql);
            if (!effect.Any())
            {
                return new Response<List<Order>>(HttpStatusCode.NotFound,"No orders found");
            }
            return new Response<List<Order>>(effect.ToList());
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> AddOrder(Order order)
    {
        try
        {
            string cmd = "Insert into orders (customerid, tableid,status) values (@CustomerId, @TableId, @Status)";
            using var _context = context.GetConnection();
            var effect =await _context.ExecuteAsync(cmd, order);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(true);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> UpdateOrder(int id, string status)
    {
        try
        {
            string cmd = "Update orders set status=@status where id=@id";
            using var _context = context.GetConnection();
            var effect = await _context.ExecuteAsync(cmd, id);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(true);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}