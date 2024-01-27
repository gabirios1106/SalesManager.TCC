using DataTransferObjects.Departments;
using Microsoft.AspNetCore.Components;
using SalesManager.Web.Interfaces;

namespace SalesManager.Web.Pages.Selects
{
    public class SelectDepartmentComponentBase : ComponentBase
    {
        [Parameter] public string DepartmentSelected { get; set; }
        [Parameter] public EventCallback<int> ChangeDepartment { get; set; }
        [Inject] IDepartmentService DepartmentService { get; set; }
            
        protected List<DepartmentGetDTO> departmentsGetDTO = new List<DepartmentGetDTO>();
        protected bool PageIsReady { get; set; }

        protected async override Task OnInitializedAsync() => await GetDepartmentsAsync();

        private async Task GetDepartmentsAsync()
        {
            departmentsGetDTO = await DepartmentService.GetDepartmentsAsync($"Departments?idUser={Program.GetIdUser()}&showInactive=false");

            PageIsReady = true;
            StateHasChanged();
        }

        protected async Task OnChangeDepartmentAsync(string selectedDepartment)
        {
            if (int.TryParse(selectedDepartment, out int departmentId) && ChangeDepartment.HasDelegate) 
            {
                DepartmentSelected = selectedDepartment;
                await ChangeDepartment.InvokeAsync(departmentId);
            }
        }
    }
}
