using Cobranca.Application.InputModel;
using Cobranca.Infra.GatewayPayment;
using Cobranca.Infra.GatewayPayment.Const;
using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Cobrancas.Domain.Models;
using Cobrancas.Domain.Repositories;


public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISubscriptionGatewayPayment _subscriptionGateway;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository,ICustomerRepository customerRepository,ISubscriptionGatewayPayment subscriptionGateway)
    {
        _subscriptionRepository = subscriptionRepository;
        this._customerRepository = customerRepository;
        this._subscriptionGateway = subscriptionGateway;
    }

    public async Task<Subscription?> GetSubscriptionAsync(int id)
    {
        return await _subscriptionRepository.Get(id);
    }

    public async Task<List<Subscription>> GetAllSubscriptionsAsync()
    {
        return await _subscriptionRepository.Get();
    }

    public async Task CreateSubscriptionAsync(SubscriptionInputModel subscription)
    {

        var subscriptionEntity = subscription.ToEntity();
        subscriptionEntity.SetCustomer( await _customerRepository.Get(subscriptionEntity.CustomerId));
        var idpayment =await _subscriptionGateway.Create(SubscriptionInputModelAsaas.FromEntity(subscriptionEntity));
        subscriptionEntity.SetIdSubscription(idpayment);
        await _subscriptionRepository.Create(subscriptionEntity);
    }

    public async Task UpdateSubscriptionAsync(Subscription subscription)
    {
        if (subscription == null)
            throw new ArgumentNullException(nameof(subscription));

        await _subscriptionRepository.Update(subscription);
    }

    public async Task DeleteSubscriptionAsync(int id)
    {
        var subscription = await _subscriptionRepository.Get(id);
        if (subscription == null)
            throw new KeyNotFoundException("Subscription not found.");

        await _subscriptionRepository.Delete(subscription);
    }

    public async Task UpdateSubscriptionFromWebHookAsync(WebHookAsaas webhook)
    {
        var subscription = await _subscriptionRepository.GetByIdPayment(webhook.payment.subscription);

        switch (webhook._event)
        {
            case PaymentEvents.PaymentConfirmed:
            case PaymentEvents.PaymentReceived:
                subscription.Active();
                break;
            case PaymentEvents.PaymentDeleted:
                subscription.Delete();
                break;           
            case PaymentEvents.PaymentOverdue:
                subscription.Disable();
                break;
            default:
                break;
        }

        await _subscriptionRepository.Update(subscription);
    }
}
