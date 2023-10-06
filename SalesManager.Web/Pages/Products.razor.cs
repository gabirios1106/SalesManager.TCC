using DataTransferObjects.Departments;
using DataTransferObjects.Products;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace SalesManager.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject] private IDialogService DialogService { get; set; }
        protected string state = "Message box hasn't been opened yet";

        protected string searchString = "";
        protected bool dense = false;
        protected bool hover = true;
        protected bool ronly = false;
        protected bool canCancelEdit = false;
        protected bool blockSwitch = false;
        protected ProductGetDTO productGetDTO = new ProductGetDTO();
        public bool IsVisible { get; set; } = false;

        protected List<ProductGetDTO> productsGetDTO = new List<ProductGetDTO>()
        {
            new ProductGetDTO() { Id = 1, ProductName = "Camisa social", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 2, ProductName = "Calça", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 3, ProductName = "Iphone", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 4, ProductName = "Farinha lacta", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 5, ProductName = "Strogonof", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 6, ProductName = "Coca Cola", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 7, ProductName = "Fanta Laranja", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 8, ProductName = "Civic SI", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 9, ProductName = "Camaro", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now },
            new ProductGetDTO() { Id = 10, ProductName = "Nivus", Price = 10.0, MinimumStock = 5, BalanceStock = 10, DepartmentId = 1,  CreatedAt = DateTime.Now }
        };

        protected async void OnButtonClicked()
        {
            bool? result = await DialogService.ShowMessageBox(
                "Cuidado",
                "Você tem certeza que quer deletar esse produto?",
                yesText: "Deletar!", cancelText: "Cancelar");
            state = result == null ? "Canceled" : "Deleted!";
            StateHasChanged();
        }

        protected void OpenCloseModal() => IsVisible = !IsVisible;

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
    }
}
