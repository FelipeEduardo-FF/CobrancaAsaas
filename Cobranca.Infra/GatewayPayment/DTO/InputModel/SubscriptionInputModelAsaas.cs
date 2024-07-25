using Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment.DTO.InputModel
{
    public class SubscriptionInputModelAsaas
    {
        public string billingType { get; set; }
        public string cycle { get; set; }
        public string customer { get; set; }
        public int value { get; set; }
        public string nextDueDate { get; set; }

        public static SubscriptionInputModelAsaas FromEntity(Subscription subscription)
        {
            return new SubscriptionInputModelAsaas
            {
                billingType = subscription.BillingType.ToString().ToUpper(),
                cycle = "MONTHLY",
                customer = subscription.Customer.IdGatewayPayment,
                value = (int)subscription.Amount,
                nextDueDate = subscription.FirstPayment.ToString("yyyy/MM/dd")
            };
        }
    }


}
