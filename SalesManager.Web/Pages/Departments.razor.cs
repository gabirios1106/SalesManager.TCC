using DataTransferObjects.Departments;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace SalesManager.Web.Pages
{
    public class DepartmentsBase : ComponentBase
    {
        [Inject] private IDialogService DialogService { get; set; }
        protected string state = "Message box hasn't been opened yet";

        protected string searchString = "";
        protected bool dense = false;
        protected bool hover = true;
        protected bool ronly = false;
        protected bool canCancelEdit = false;
        protected bool blockSwitch = false;
        protected DepartmentGetDTO departmentGetDTO = new DepartmentGetDTO();
        public bool IsVisible { get; set; } = false;

        protected List<DepartmentGetDTO> departmentsGetDTO = new List<DepartmentGetDTO>()
        {
            new DepartmentGetDTO() { Id = 1, DepartmentName = "Roupas", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 2, DepartmentName = "Eletrônicos", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 3, DepartmentName = "Domésticos", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 4, DepartmentName = "Celulares", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 5, DepartmentName = "Instrumentos", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 6, DepartmentName = "Cozinha", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 7, DepartmentName = "Escritório", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 8, DepartmentName = "Cama", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 9, DepartmentName = "Mesa", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 10, DepartmentName = "Banho", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 11, DepartmentName = "Alimentos", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 12, DepartmentName = "Bebidas", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 13, DepartmentName = "Carros", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 14, DepartmentName = "Esportes", CreatedAt = DateTime.Now },
            new DepartmentGetDTO() { Id = 15, DepartmentName = "Informática", CreatedAt = DateTime.Now }
        };

        protected async void OnButtonClicked()
        {
            bool? result = await DialogService.ShowMessageBox(
                "Cuidado",
                "Você tem certeza que quer deletar esse departamento?",
                yesText: "Deletar!", cancelText: "Cancelar");
            state = result == null ? "Canceled" : "Deleted!";
            StateHasChanged();
        }

        protected void OpenCloseModal() => IsVisible = !IsVisible;

        protected bool FilterFunc(DepartmentGetDTO departmentGetDTO)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (departmentGetDTO.DepartmentName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (departmentGetDTO.CreatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
