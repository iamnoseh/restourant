using Domain;
namespace Infrastructure;

public interface ICustomerService
{
    public Task<Response<List<Customer>>> GetCustomerAsync();
    public Task<Response<Customer>> GetCustomerByPhoneAsync(string phone); 
    public Task<Response<bool>> AddCustomerAsync(Customer customer);

}