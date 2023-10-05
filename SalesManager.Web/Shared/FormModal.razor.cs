using Microsoft.AspNetCore.Components;

namespace SalesManager.Web.Shared
{
    public class FormModalBase : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback CloseModal { get; set; }
    }
}