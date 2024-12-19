using System.Net;
using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.TableService;

public class TableService(DapperContext context):ITableService
{
    public async Task<Response<List<Table>>> GetTablesAsync()
    {
        try
        {
            string sql = "select * from tables";
            using var _context = context.GetConnection();
            var effect = await _context.QueryAsync<Table>(sql);
            if (!effect.Any())
            {
                return new Response<List<Table>>(HttpStatusCode.NotFound,"No tables found");
            
            }
            return new Response<List<Table>>(effect.ToList());
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<bool>> UpdateTableRezervAsync(int tableId)
    {
        try
        {
            string sql = "update tables set status='busy' where id=@tableId";
            using var _context = context.GetConnection();
            var effect = await _context.ExecuteAsync(sql, new { tableId });
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

    public async Task<Response<bool>> UpdateTableFreeAsync(int tableId)
    {
        try
        {
            string sql = "update tables set status='free' where id=@tableId";
            using var _context = context.GetConnection();
            var effect = await _context.ExecuteAsync(sql, new { tableId });
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