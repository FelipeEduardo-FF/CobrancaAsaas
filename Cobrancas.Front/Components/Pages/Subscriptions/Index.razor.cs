using Cobrancas.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Cobrancas.Components.Pages.Subscriptions
{
    public class IndexSubscriptionPage:ComponentBase
    {
        [Inject]
        public ISubscriptionService SubscriptionService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public List<Subscription> ListSubscriptions { get; set; } = new List<Subscription>();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                ListSubscriptions = await SubscriptionService.GetAllSubscriptionsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
