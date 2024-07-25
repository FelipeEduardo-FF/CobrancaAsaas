using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment
{
    public interface ISubscriptionGatewayPayment
    {
        Task<string> Create(SubscriptionInputModelAsaas payment);

    }
}
