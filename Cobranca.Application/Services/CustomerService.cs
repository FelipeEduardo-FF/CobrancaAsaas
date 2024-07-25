using Cobranca.Application.InputModel;
using Cobranca.Infra.Gateway;
using Cobranca.Infra.GatewayPayment;
using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Cobrancas.Domain.Models;
using Cobrancas.Domain.Repositories;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _custumerRepository;
    private readonly ICustomerGatewayPayment _customerGatewayPayment;

    public CustomerService(ICustomerRepository customerRepository, ICustomerGatewayPayment customerGatewayPayment)
    {
        _custumerRepository = customerRepository;
        _customerGatewayPayment = customerGatewayPayment;
    }

    public async Task<Customer?> GetCostumerAsync(int id)
    {
        return await _custumerRepository.Get(id);
    }

    public async Task<List<Customer>> GetAllCostumersAsync()
    {
        return await _custumerRepository.Get();
    }

    public async Task CreateCostumerAsync(CostumerInputModel costumer)
    {

        var entityCustomer=costumer.ToEntity();
        var idCostumer = await _customerGatewayPayment.CreateCostumer(CustomernputModelAsaas.FromEntity(entityCustomer));

        entityCustomer.SetIdGatewayPayment(idCostumer);

        await _custumerRepository.Create(entityCustomer);
    }

    public async Task UpdateCostumerAsync(CostumerUpdateInputModel costumerupdate)
    {
        var costumer = await _custumerRepository.Get(costumerupdate.Id);
        if (costumer == null)
            throw new KeyNotFoundException("Costumer not found.");

        costumer.Update(costumerupdate.Name, costumerupdate.Document, costumerupdate.PhoneNumber, costumerupdate.Email);

        await _custumerRepository.Update(costumer);
    }

    public async Task DeleteCostumerAsync(int id)
    {
        var costumer = await _custumerRepository.Get(id);
        if (costumer == null)
            throw new KeyNotFoundException("Costumer not found.");

        await _custumerRepository.Delete(costumer);
    }
}
