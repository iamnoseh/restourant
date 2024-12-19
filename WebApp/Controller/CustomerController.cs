using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Customer>>> Get()
    {
            var res = service.GetCustomerAsync();
            return await res;
    }

    [HttpGet("{phonenumber}")]
    public async Task<Response<Customer>> Get(string phonenumber)
    {
             var res = service.GetCustomerByPhoneAsync(phonenumber);
            return await res;
    }

    [HttpPost]
    public async Task<Response<bool>> Post(Customer customer)
    {
            var res = service.AddCustomerAsync(customer);
            return await res;
  
    }
}