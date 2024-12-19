using Domain;

namespace Infrastructure.TableService;

public interface ITableService
{
    Task<Response<List<Table>>> GetTablesAsync();
    Task<Response<bool>> UpdateTableRezervAsync(int tableId);
    Task<Response<bool>> UpdateTableFreeAsync(int tableId);
}