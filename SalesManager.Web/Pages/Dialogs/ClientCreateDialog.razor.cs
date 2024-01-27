﻿using DataTransferObjects.Clients;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SalesManager.Web.Interfaces;

namespace SalesManager.Web.Pages.Dialogs
{
    public class ClientsCreateDialogBase : ComponentBase
    {
        [Inject] ISnackbar SnackbarService { get; set; }
        [Inject] IClientService ClientService { get; set; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public EventCallback GetClientsAsync { get; set; }

        protected ClientPostDTO ClientPostDTO { get; set; } = new ClientPostDTO(Program.GetIdUser());
        protected bool PageIsReady { get; set; }

        protected override void OnInitialized() => PageIsReady = true;

        protected async void CreateClientAsync()
        {
            PageIsReady = !PageIsReady;

            bool createSucessfull = await ClientService.CreateAsync("Clients", ClientPostDTO);

            if (createSucessfull)
            {
                SnackbarService.Add("Cliente cadastrado com sucesso", Severity.Success);

                await GetClientsAsync.InvokeAsync();
                StateHasChanged();
                MudDialog.Close();
            }

            PageIsReady = !PageIsReady;
        }

        protected void Cancel() => MudDialog.Cancel();
    }
}
