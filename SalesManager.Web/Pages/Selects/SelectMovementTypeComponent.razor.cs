using DataTransferObjects.Departments;
using Microsoft.AspNetCore.Components;
using Models;

namespace SalesManager.Web.Pages.Selects
{
    public class SelectMovementTypeComponentBase : ComponentBase
    {
        [Parameter] public string MovementTypeSelected { get; set; }
        [Parameter] public EventCallback<MovementType> ChangeMovementType { get; set; }
        protected IEnumerable<MovementType> MovementTypes { get; set; }
        protected bool PageIsReady { get; set; }

        protected async override Task OnInitializedAsync() => await GetMovementTypes();

        private async Task GetMovementTypes()
        {
            PageIsReady = true;
            MovementTypes = Enum.GetValues(typeof(MovementType)).Cast<MovementType>();

            StateHasChanged();
        }

        protected async Task OnChangeMovementTypeAsync(string movementTypeSelected)
        { 
            if (Enum.TryParse(movementTypeSelected, out MovementType movementType) && ChangeMovementType.HasDelegate)
            {
                MovementTypeSelected = movementTypeSelected;
                await ChangeMovementType.InvokeAsync(movementType);
            }

        }
    }
}
