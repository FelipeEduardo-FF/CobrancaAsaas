using Cobranca.Infra.GatewayPayment.Const;
using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Cobranca.Infra.GatewayPayment.DTO.ViewModel;
using Cobrancas.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment
{
    public class SubscriptionGatewayPayment : ISubscriptionGatewayPayment
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public SubscriptionGatewayPayment(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accessToken = configuration["AsaasAccessToken"];
        }
        public async Task<string> Create(SubscriptionInputModelAsaas payment)
        {

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Cobranca");
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("access_token", _accessToken);

            var jsonContent = JsonSerializer.Serialize(payment);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ConstAsaas.Url+ConstAsaas.Subscription, content);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var subscriptionResponse = JsonSerializer.Deserialize<SubscriptionAsaasViewModel>(body);
                return subscriptionResponse.id;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao criar assinatura: {response.StatusCode} - {errorContent}");
            }
        }
    }
}
