using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveTypes;

public partial class Details
{
    [Inject]
    ILeaveTypeService _client { get; set; }

    [Parameter]
    public int Id { get; set; }

    private LeaveTypeVm leaveType = new();

    protected async override Task OnParametersSetAsync()
    {
        leaveType = await _client.GetLeaveTypeDetails(Id);
    }
}
