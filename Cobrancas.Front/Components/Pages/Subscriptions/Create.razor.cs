using Cobranca.Application.InputModel;
using Cobrancas.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Cobrancas.Components.Pages.Subscriptions
{
    public class CreateSubscriptionPage : ComponentBase
    {
        [Inject]
        public ISubscriptionService SubscriptionService { get; set; } = null!;

        [Inject]
        public ICustomerService CostumerService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public SubscriptionInputModel InputModel { get; set; } = new();

        public List<Customer> Customers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = await CostumerService.GetAllCostumersAsync();
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is SubscriptionInputModel model)
                {

                    await SubscriptionService.CreateSubscriptionAsync(model);
                    Snackbar.Add("Assinatura atualizada com sucesso", Severity.Success);

                    NavigationManager.NavigateTo("/subscriptions");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
