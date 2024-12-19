using Domain;
using Infrastructure;
using Infrastructure.TableService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class TableController(ITableService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Table>>> GetTables()
    {
        try
        {
            var tables = await service.GetTablesAsync();
            return tables;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("book/{tableId}")]
    public async Task<Response<bool>> PutBook(int tableId)
    {

            var res = service.UpdateTableRezervAsync(tableId);
            return await res;
        
    }

    [HttpPut("free/{tableId}")]
    public async Task<Response<bool>> PutFreeBook(int tableId)
    {

            var res = service.UpdateTableFreeAsync(tableId);
            return await res;
     
    }
}