using DataTransferObjects.Clients;
using DataTransferObjects.Departments;
using DataTransferObjects.Products;
using Microsoft.AspNetCore.Components;
using Models;
using MudBlazor;
using SalesManager.Web.Interfaces;
using SalesManager.Web.Pages.Dialogs;

namespace SalesManager.Web.Pages
{
    public class ClientsBase : ComponentBase
    {
        [Inject] IClientService ClientService { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISnackbar SnackbarService { get; set; }

        protected bool confirmDelete = false;

        protected string searchString = "";
        protected bool dense = false;
        protected bool hover = true;
        protected bool ronly = false;
        protected bool canCancelEdit = false;
        protected bool blockSwitch = false;
        protected bool statusClient = false;

        protected ClientPutDTO clientPutDTO = new ClientPutDTO();

        public IMask emailMask = RegexMask.Email();

        public bool IsLoading { get; set; } = false;

        protected List<ClientGetDTO> clientsGetDTO = new List<ClientGetDTO>();
        protected List<ClientGetDTO> clientsGetDTOToShow = new List<ClientGetDTO>();

        protected async override Task OnInitializedAsync()
        {
            await GetClientsAsync();
        }

        protected void ChangeStatusOption()
        {
            statusClient = !statusClient;
            FilterClientsToShow();
            StateHasChanged();
        }

        protected async Task GetClientsAsync()
        {
            IsLoading = true;
            StateHasChanged();

            clientsGetDTO = await ClientService.GetClientsAsync($"Clients?idUser={Program.GetIdUser()}");
            IsLoading = false;
            FilterClientsToShow();
            StateHasChanged();
        }

        private void FilterClientsToShow() => clientsGetDTOToShow = clientsGetDTO.Where(c => c.Status == (statusClient ? 0 : 1)).ToList();

        protected async void OnButtonClicked(int clientId)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.ExtraSmall,
                FullWidth = true
            };

            bool? result = await DialogService.ShowMessageBox(
                "Cuidado",
                "Você tem certeza que quer deletar esse departamento?",
                yesText: "Deletar!", cancelText: "Cancelar",
                options: dialogOptions);

            confirmDelete = result == null ? false : true;

            if (confirmDelete)
            {
                bool deleteClient = await ClientService.DeleteAsync($"Clients/{clientId}");

                if (deleteClient)
                {
                    await GetClientsAsync();

                    string message = (clientsGetDTO.Any(c => c.Status == 0 && c.Id == clientId)) ? "desativado" : "excluído";
                    SnackbarService.Add($"Cliente {message} com sucesso", Severity.Success);
                }

                StateHasChanged();
            }
        }

        protected bool FilterFunc(ClientGetDTO clientGetDTO)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (clientGetDTO.ClientName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (clientGetDTO.CreatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected async void ActiveClientsAsync(ClientGetDTO clientGetDTO)
        {
            clientPutDTO = new ClientPutDTO(clientGetDTO);
            clientPutDTO.Status = 1;

            bool updateSucessfull = await ClientService.UpdateAsync("Clients", clientPutDTO);

            if (updateSucessfull)
            {
                await GetClientsAsync();
                SnackbarService.Add("Cliente ativado com sucesso", Severity.Success);
            }

            StateHasChanged();
        }

        protected void ShowCreateModal()
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<ClientCreateDialog>();
            dialogParameters.Add("GetClientsAsync", EventCallback.Factory.Create(this, GetClientsAsync));

            DialogService.Show<ClientCreateDialog>("Cadastrar cliente", dialogParameters, dialogOptions);
        }

        protected void ShowUpdateModal(ClientGetDTO clientGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<ClientUpdateDialog>();
            dialogParameters.Add("ClientPutDTO", new ClientPutDTO(clientGetDTO));
            dialogParameters.Add("GetClientsAsync", EventCallback.Factory.Create(this, GetClientsAsync));

            DialogService.Show<ClientUpdateDialog>("Atualizar Cliente", dialogParameters, dialogOptions);
        }
        protected void ShowDetailsModal(ClientGetDTO clientGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<ClientDetailsDialog>();
            dialogParameters.Add("ClientGetDTO", clientGetDTO);

            DialogService.Show<ClientDetailsDialog>(clientGetDTO.ClientName, dialogParameters, dialogOptions);
        }
    }
}
