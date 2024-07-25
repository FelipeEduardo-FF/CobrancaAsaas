using Cobranca.Application.InputModel;
using Cobrancas.Domain.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace Cobrancas.Components.Pages.Costumers
{
    public class CostumerCreatePage : ComponentBase
    {
        [Inject]
        public ICustomerService CostumerService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public CostumerInputModel InputModel { get; set; } = new CostumerInputModel();

        public DateTime? MaxDate { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync()
        {
            try
            {

                await CostumerService.CreateCostumerAsync(InputModel);
                Snackbar.Add("Cliente cadastrado com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/costumers");
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
