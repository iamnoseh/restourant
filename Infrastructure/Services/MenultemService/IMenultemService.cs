using Domain;

namespace Infrastructure.MenultemService;

public interface IMenultemService
{
    Task<Response<List<Menultem>>> GetMenultemAsync();
    Task<Response<bool>> AddMenultemAsync(Menultem menultem);
}