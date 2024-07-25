using Azure.Core;
using Cobranca.Infra.Gateway;
using Cobranca.Infra.GatewayPayment.Const;
using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Cobranca.Infra.GatewayPayment.DTO.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment
{
    public class CustomerGatewayPayment : ICustomerGatewayPayment
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public CustomerGatewayPayment(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accessToken = configuration["AsaasAccessToken"];
        }

        public async Task<string> CreateCostumer(CustomernputModelAsaas costumer)
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Cobranca");
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("access_token", _accessToken);

            var jsonContent = JsonSerializer.Serialize(costumer);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ConstAsaas.Url+ConstAsaas.Costumer, content);

            if (response.IsSuccessStatusCode)
            {
                var body= await response.Content.ReadAsStringAsync();
                var customerResponse = JsonSerializer.Deserialize<CustomerAsaasViewModel>(body);
                return customerResponse.id;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao criar cliente: {response.StatusCode} - {errorContent}");
            }
        }
    }
}
