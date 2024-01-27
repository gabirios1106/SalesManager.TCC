using DataTransferObjects.Departments;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SalesManager.Web.Interfaces;

namespace SalesManager.Web.Pages.Dialogs
{
    public class DepartmentCreateDialogBase : ComponentBase
    {
        [Inject] ISnackbar SnackbarService { get; set; }
        [Inject] IDepartmentService DepartmentService { get; set; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public EventCallback GetDepartmentsAsync { get; set; }

        protected DepartmentPostDTO DepartmentPostDTO { get; set; } = new DepartmentPostDTO(Program.GetIdUser());
        protected bool PageIsReady { get; set; }

        protected override void OnInitialized() => PageIsReady = true;

        protected async void CreateDepartmentAsync()
        {
            PageIsReady = !PageIsReady;

            bool createSucessfull = await DepartmentService.CreateAsync("Departments", DepartmentPostDTO);

            if (createSucessfull)
            {
                SnackbarService.Add("Departamento cadastrado com sucesso", Severity.Success);

                await GetDepartmentsAsync.InvokeAsync();
                StateHasChanged();
                MudDialog.Close();
            }

            PageIsReady = !PageIsReady;
        }

        protected void Cancel() => MudDialog.Cancel();
    }
}