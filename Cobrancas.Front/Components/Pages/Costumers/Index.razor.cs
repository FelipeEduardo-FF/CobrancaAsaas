using Cobrancas.Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cobrancas.Components.Pages.Costumers
{
    public class CostumerIndexPage:ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Customer> Costumers { get; set; } = new List<Customer>();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public bool HideButtons { get; set; }

        public async Task DeleteCostumer(Customer costumer)
        {
            try
            {
                var result = await Dialog.ShowMessageBox(
                    "Atenção",
                    $"Deseja excluir o cliente {costumer.Name}?",
                    yesText: "SIM",
                    cancelText: "NÃO"
                );

                if (result is true)
                {
                    await CustomerService.DeleteCostumerAsync(costumer.Id);
                    Snackbar.Add($"Cliente {costumer.Name} excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/costumers/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var auth = await AuthenticationState;

                HideButtons = !auth.User.IsInRole("Adm");

                Costumers = await CustomerService.GetAllCostumersAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

