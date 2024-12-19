using Domain;
using Infrastructure;
using Infrastructure.MenultemService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenultemService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Menultem>>> GetMenultems()
    {
            var res = service.GetMenultemAsync();
            return await res;
    }

    [HttpPost]
    public async Task<Response<bool>> PostMenultem(Menultem menultem)
    {
            var res = service.AddMenultemAsync(menultem);
            return await res;
    }
    
}