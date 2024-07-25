using Cobranca.Application.InputModel;
using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Cobrancas.Domain.Models;

public interface ISubscriptionService
{
    Task<Subscription?> GetSubscriptionAsync(int id);
    Task<List<Subscription>> GetAllSubscriptionsAsync();
    Task CreateSubscriptionAsync(SubscriptionInputModel subscription);
    Task UpdateSubscriptionAsync(Subscription subscription);
    Task UpdateSubscriptionFromWebHookAsync(WebHookAsaas webhook);
    Task DeleteSubscriptionAsync(int id);
}
