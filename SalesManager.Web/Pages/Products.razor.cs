﻿using DataTransferObjects.Departments;
using DataTransferObjects.Products;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SalesManager.Web.Interfaces;
using SalesManager.Web.Pages.Dialogs;
using System.Globalization;

namespace SalesManager.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject] IProductService ProductService { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISnackbar SnackbarService { get; set; }

        protected bool confirmDelete = false;
        protected string searchString = "";
        protected bool dense = false;
        protected bool hover = true;
        protected bool ronly = false;
        protected bool canCancelEdit = false;
        protected bool blockSwitch = false;
        protected bool statusProduct = false;
        protected ProductGetDTO productGetDTO = new ProductGetDTO();
        protected ProductPostDTO productPostDTO = new ProductPostDTO();
        protected ProductPutDTO productPutDTO = new ProductPutDTO();
        public bool IsVisible { get; set; } = false;
        public bool IsVisibleUpdate { get; set; } = false;
        public bool IsVisibleDetail { get; set; } = false;
        public bool IsLoading { get; set; } = false;

        protected List<ProductGetDTO> productsGetDTO = new List<ProductGetDTO>();
        protected List<ProductGetDTO> productsGetDTOToShow = new List<ProductGetDTO>();
        protected CultureInfo CultureInfoPtBR { get; set; } = new CultureInfo("pt-BR");

        protected async override Task OnInitializedAsync()
        {
            await GetProductsAsync();
        }

        protected void ChangeStatusOption()
        {
            statusProduct = !statusProduct;
            FilterProductsToShow();
        }

        protected async Task GetProductsAsync()
        {
            IsLoading = true;
            StateHasChanged();

            productsGetDTO = await ProductService.GetProductsAsync($"Products?idUser={Program.GetIdUser()}");
            IsLoading = false;
            FilterProductsToShow();
            StateHasChanged();
        }

        private void FilterProductsToShow() => productsGetDTOToShow = productsGetDTO.Where(p => p.Status == (statusProduct ? 0 : 1)).ToList();

        protected async void OnButtonClicked(int productId)
        {
            bool? result = await DialogService.ShowMessageBox(
                "Cuidado",
                "Você tem certeza que quer deletar esse produto?",
                yesText: "Deletar!", cancelText: "Cancelar");

            confirmDelete = result == null ? false : true;

            if (confirmDelete)
            {
                bool deleteProduct = await ProductService.DeleteAsync($"Products/{productId}");
                if (deleteProduct)
                {
                    await GetProductsAsync();

                    string message = (productsGetDTO.Any(p => p.Status == 0 && p.Id == productId)) ? "desativado" : "excluído";
                    SnackbarService.Add($"Produto {message} com sucesso", Severity.Success);
                }

                StateHasChanged();
            }
        }

        protected void OpenCloseModal() => IsVisible = !IsVisible;
        protected void OpenCloseUpdateModal() => IsVisibleUpdate = !IsVisibleUpdate;
        protected void OpenCloseDetailModal() => IsVisibleDetail = !IsVisibleDetail;

        protected bool FilterFunc(ProductGetDTO productGetDTO)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (productGetDTO.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (productGetDTO.CreatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (productGetDTO.DepartmentId.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected async void ActiveProductsAsync(ProductGetDTO productGetDTO)
        {
            productPutDTO = new ProductPutDTO(productGetDTO);
            productPutDTO.Status = 1;

            bool updateSucessfull = await ProductService.UpdateAsync("Products", productPutDTO);

            if (updateSucessfull)
            {
                await GetProductsAsync();
                SnackbarService.Add("Produto ativado com sucesso", Severity.Success);
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

            DialogParameters dialogParameters = new DialogParameters<ProductCreateDialog>();
            dialogParameters.Add("GetProductsAsync", EventCallback.Factory.Create(this, GetProductsAsync));

            DialogService.Show<ProductCreateDialog>("Cadastrar Produto", dialogParameters, dialogOptions);
        }

        protected void ShowUpdateModal(ProductGetDTO productGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<ProductUpdateDialog>();
            dialogParameters.Add("ProductPutDTO", new ProductPutDTO(productGetDTO));
            dialogParameters.Add("GetProductsAsync", EventCallback.Factory.Create(this, GetProductsAsync));

            DialogService.Show<ProductUpdateDialog>("Atualizar Produto", dialogParameters, dialogOptions);
        }

        protected void ShowDetailsModal(ProductGetDTO productGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<ProductDetailsDialog>();
            dialogParameters.Add("ProductGetDTO", productGetDTO);

            DialogService.Show<ProductDetailsDialog>(productGetDTO.ProductName, dialogParameters, dialogOptions);
        }
    }
}
