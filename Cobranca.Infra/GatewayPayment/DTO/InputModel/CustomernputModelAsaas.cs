using Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment.DTO.InputModel
{
    public class CustomernputModelAsaas
    {
        public CustomernputModelAsaas(string name, string cpfCnpj, string email)
        {
            this.name = name;
            this.cpfCnpj = cpfCnpj;
            this.email = email;
        }

        public string name { get; set; }
        public string cpfCnpj { get; set; }
        public string email { get; set; }

        public static CustomernputModelAsaas FromEntity(Customer costumer)
        {
            return new CustomernputModelAsaas(costumer.Name,costumer.Document,costumer.Email);
        }
    }

}
