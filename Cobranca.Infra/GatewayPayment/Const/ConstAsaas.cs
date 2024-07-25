using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Cobranca.Infra.GatewayPayment.Const
{
    public static class ConstAsaas
    {
        public const string Url = "https://sandbox.asaas.com/api/v3";
        public const string Costumer = "/customers";
        public const string Subscription = "/subscriptions";
    }
}
