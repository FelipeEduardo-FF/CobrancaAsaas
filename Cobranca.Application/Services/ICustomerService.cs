using Cobranca.Application.InputModel;
using Cobrancas.Domain.Models;

public interface ICustomerService
{
    Task<Customer?> GetCostumerAsync(int id);
    Task<List<Customer>> GetAllCostumersAsync();
    Task CreateCostumerAsync(CostumerInputModel costumer);
    Task UpdateCostumerAsync(CostumerUpdateInputModel costumer);
    Task DeleteCostumerAsync(int id);
}
