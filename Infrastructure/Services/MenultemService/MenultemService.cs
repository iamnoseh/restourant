using System.Net;
using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.MenultemService;

public class MenultemService(DapperContext context):IMenultemService
{
    public async Task<Response<List<Menultem>>> GetMenultemAsync()
    {
        try
        {
            string sql = "select * from menultems";
            using var _context = context.GetConnection();
            var effect = await _context.QueryAsync<Menultem>(sql);
            if (!effect.Any())
            {
                return new Response<List<Menultem>>(HttpStatusCode.NotFound,"Not found");
            
            }

            return new Response<List<Menultem>>(effect.ToList());
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> AddMenultemAsync(Menultem menultem)
    {
        try
        {
            string cmd = "Insert into menultems(name,price,category) values(@Name,@Price,@Category)";
            using var _context = context.GetConnection();
            var effect = await _context.ExecuteAsync(cmd, menultem);
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