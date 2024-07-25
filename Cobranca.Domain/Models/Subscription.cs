using Cobrancas.Domain.Enum;

namespace Cobrancas.Domain.Models
{
    public class Subscription
    {
        public Subscription(BillingTypeEnum billingType, float amount, DateTime firstPayment, int customerId)
        {
            BillingType = billingType;
            Status = SubscriptionStatus.Created;
            Amount = amount;
            FirstPayment = firstPayment;
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public BillingTypeEnum BillingType { get;private set; }
        public SubscriptionStatus Status { get; private set; }
        public float Amount { get; private set; }
        public DateTime FirstPayment { get; private set; }
        public int CustomerId { get; private set; }
        public Customer? Customer { get; private set; }
        public string IdSubscription { get; private set; }

        public void SetCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void SetIdSubscription(string idSubscription)
        {
            IdSubscription = idSubscription;
        }

        public void Delete()
        {
            Status = SubscriptionStatus.Deleted;
        }

        public void Active()
        {
            Status = SubscriptionStatus.Active;
        }
        public void Disable()
        {
            Status = SubscriptionStatus.Disabled;
        }
    }
}
