using Cobrancas.Domain.Models;

namespace Cobrancas.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(Customer costumer);
        Task Delete(Customer costumer);
        Task<Customer> Get(int id);
        Task Update(Customer costumer);
        Task<List<Customer>> Get();

    }
}
