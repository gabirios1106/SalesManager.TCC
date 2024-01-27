﻿using DataTransferObjects.StockMovement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SalesManager.Web.Interfaces;

namespace SalesManager.Web.Pages.Dialogs
{
    public class StockMovementCreatePurchaseDialogBase : ComponentBase
    {
        [Inject] ISnackbar SnackbarService { get; set; }
        [Inject] IStockMovementService StockMovementService { get; set; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public EventCallback GetStockMovementsAsync { get; set; }

        protected StockMovementPurchasePostDTO StockMovementPurchasePostDTO { get; set; } = new StockMovementPurchasePostDTO(Program.GetIdUser());
        protected bool PageIsReady { get; set; }

        protected override void OnInitialized() => PageIsReady = true;

        protected async void CreateStockMovementPurchaseAsync()
        {
            PageIsReady = !PageIsReady;

            bool createSucessfull = await StockMovementService.CreatePurchaseAsync("StockMovement", StockMovementPurchasePostDTO);

            if (createSucessfull)
            {
                SnackbarService.Add("Compra cadastrado com sucesso", Severity.Success);

                await GetStockMovementsAsync.InvokeAsync();
                MudDialog.Close();
            }

            StateHasChanged();
            PageIsReady = !PageIsReady;
        }

        protected void ChangeProductIdCreatePurchase(int productId)
        {
            if (StockMovementPurchasePostDTO is null) return;

            StockMovementPurchasePostDTO.ProductId = productId;
        }

        protected void Cancel() => MudDialog.Cancel();
    }
}
