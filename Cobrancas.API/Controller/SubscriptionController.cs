using Cobranca.Infra.GatewayPayment.DTO.InputModel;
using Microsoft.AspNetCore.Mvc;

namespace Cobrancas.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            this._subscriptionService = subscriptionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] WebHookAsaas inputModel)
        {
            await _subscriptionService.UpdateSubscriptionFromWebHookAsync(inputModel);

            return Ok();
        }
    }
}
