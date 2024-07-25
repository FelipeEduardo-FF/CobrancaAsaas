using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment.DTO.InputModel
{


    public class WebHookAsaas
    {
        public string id { get; set; }
        [JsonPropertyName("event")]
        public string _event { get; set; }
        public Payment payment { get; set; }
    }

    public class Payment
    {
        public string subscription { get; set; }
    }



}
