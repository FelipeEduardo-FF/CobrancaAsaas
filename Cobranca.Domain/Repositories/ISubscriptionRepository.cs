using Cobrancas.Domain.Models;

namespace Cobrancas.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task Create(Subscription subscription);
        Task Delete(Subscription subscription);
        Task<Subscription> Get(int id);
        Task<Subscription> GetByIdPayment(string id);
        Task Update(Subscription subscription);
        Task<List<Subscription>> Get();
    }
}
