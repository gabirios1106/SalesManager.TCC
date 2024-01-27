using DataTransferObjects.Departments;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SalesManager.Web.Interfaces;
using SalesManager.Web.Pages.Dialogs;

namespace SalesManager.Web.Pages
{
    public class DepartmentsBase : ComponentBase
    {
        [Inject] IDepartmentService DepartmentService { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISnackbar SnackbarService { get; set; }

        protected bool confirmDelete = false;

        protected string searchString = "";
        protected bool dense = false;
        protected bool hover = true;
        protected bool ronly = false;
        protected bool canCancelEdit = false;
        protected bool blockSwitch = false;
        protected bool statusDepartment = false;

        public bool IsLoading { get; set; } = false;

        protected List<DepartmentGetDTO> departmentsGetDTO = new List<DepartmentGetDTO>();
        protected List<DepartmentGetDTO> departmentsGetDTOToShow = new List<DepartmentGetDTO>();

        protected async override Task OnInitializedAsync()
        {
            await GetDepartmentsAsync();
        }

        protected void ChangeStatusOption()
        {
            statusDepartment = !statusDepartment;
            FilterDepartmentsToShow();
            StateHasChanged();
        }

        protected async Task GetDepartmentsAsync()
        {
            IsLoading = true;
            StateHasChanged();

            departmentsGetDTO = await DepartmentService.GetDepartmentsAsync($"Departments?idUser={Program.GetIdUser()}");
            IsLoading = false;
            FilterDepartmentsToShow();
            StateHasChanged();
        }

        private void FilterDepartmentsToShow() => departmentsGetDTOToShow = departmentsGetDTO.Where(d => d.Status == (statusDepartment ? 0 : 1)).ToList();

        protected async void OnButtonClicked(int departmentId)
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
                bool deleteDepartment = await DepartmentService.DeleteAsync($"Departments/{departmentId}");

                if (deleteDepartment)
                {
                    await GetDepartmentsAsync();

                    string message = (departmentsGetDTO.Any(d => d.Status == 0 && d.Id == departmentId)) ? "desativado" : "excluído";
                    SnackbarService.Add($"Departamento {message} com sucesso", Severity.Success);
                }

                StateHasChanged();
            }
        }

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

        protected async void ActiveDepartmentsAsync(DepartmentGetDTO departmentGetDTO)
        {
            DepartmentPutDTO departmentPutDTO = new DepartmentPutDTO(departmentGetDTO);
            departmentPutDTO.Status = 1;

            bool updateSucessfull = await DepartmentService.UpdateAsync("Departments", departmentPutDTO);

            if (updateSucessfull)
            {
                await GetDepartmentsAsync();
                SnackbarService.Add("Departamento ativado com sucesso", Severity.Success);
            }

            StateHasChanged();
        }

        protected void ShowCreateModal()
        {
            Console.WriteLine("Oi");

            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<DepartmentCreateDialog>();
            dialogParameters.Add("GetDepartmentsAsync", EventCallback.Factory.Create(this, GetDepartmentsAsync));

            DialogService.Show<DepartmentCreateDialog>("Cadastrar Departamento", dialogParameters, dialogOptions);
        }

        protected void ShowUpdateModal(DepartmentGetDTO departmentGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<DepartmentUpdateDialog>();
            dialogParameters.Add("DepartmentPutDTO", new DepartmentPutDTO(departmentGetDTO));
            dialogParameters.Add("GetDepartmentsAsync", EventCallback.Factory.Create(this, GetDepartmentsAsync));

            DialogService.Show<DepartmentUpdateDialog>("Atualizar Departamento", dialogParameters, dialogOptions);
        }

        protected void ShowDetailsModal(DepartmentGetDTO departmentGetDTO)
        {
            DialogOptions dialogOptions = new DialogOptions
            {
                ClassBackground = "blurry-dialog-class",
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            DialogParameters dialogParameters = new DialogParameters<DepartmentDetailsDialog>();
            dialogParameters.Add("DepartmentGetDTO", departmentGetDTO);

            DialogService.Show<DepartmentDetailsDialog>(departmentGetDTO.DepartmentName, dialogParameters, dialogOptions);
        }
    }
}
