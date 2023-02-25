using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveTypes;

public partial class FormComponent
{
    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public LeaveTypeVm LeaveType { get; set; } = new();

    [Parameter]
    public string ButtonText { get; set; } = "Save";

    [Parameter]
    public EventCallback OnValidSubmit { get; set; }
}
