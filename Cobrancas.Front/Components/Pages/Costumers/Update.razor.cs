using Cobranca.Application.InputModel;
using Cobrancas.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Cobrancas.Components.Pages.Costumers
{
    public class CostumerUpdatePage:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public ICustomerService CostumerService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public CostumerUpdateInputModel InputModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var costumer = await CostumerService.GetCostumerAsync(Id);

            if (costumer != null)
            {
                InputModel = new CostumerUpdateInputModel
                {
                    Id=costumer.Id,
                    Name = costumer.Name,
                    Document = costumer.Document,
                    PhoneNumber = costumer.PhoneNumber,
                    Email = costumer.Email
                };
            }
            else
            {
                Snackbar.Add("Cliente não encontrado", Severity.Error);
                NavigationManager.NavigateTo("/costumers");
            }
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is CostumerUpdateInputModel model)
                {
                    await CostumerService.UpdateCostumerAsync(model);
                    Snackbar.Add("Cliente atualizado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/costumers");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
