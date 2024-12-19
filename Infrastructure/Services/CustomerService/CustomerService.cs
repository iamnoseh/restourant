using System.Net;
using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure;

public class CustomerService(DapperContext context):ICustomerService
{
    public async Task<Response<List<Customer>>> GetCustomerAsync()
    {
        try
        {
            string sql = "select * from customers";
            using var _context = context.GetConnection();
            var effect = await _context.QueryAsync<Customer>(sql);
            if (!effect.Any())
            {
                return new Response<List<Customer>>(HttpStatusCode.NotFound,"No customers found");
            }
            return new Response<List<Customer>>(effect.ToList());
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Customer>> GetCustomerByPhoneAsync(string phone)
    {
        try
        {
            string sql = "select * from customers where phonenumber = @phone";
            using var _context = context.GetConnection();
            var effect = await _context.QueryFirstOrDefaultAsync(sql);
            return effect == null 
                ? new Response<Customer>(HttpStatusCode.NotFound,"No customers found")
                : new Response<Customer>(effect);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> AddCustomerAsync(Customer customer)
    {
        try
        {
            string sql = "Insert into customers(name,phonenumber) values (@Name,@PhoneNumber)";
            using var _context = context.GetConnection();
            var effect = await _context.ExecuteAsync(sql, customer);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal server error")
                : new Response<bool>(true);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}