using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveTypes;

public partial class Edit
{
    [Inject]
    ILeaveTypeService LeaveTypeService { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public int Id { get; set; }

    public string Message { get; private set; } = "";

    private LeaveTypeVm leaveType = new();

    protected async override Task OnParametersSetAsync()
    {
        leaveType = await LeaveTypeService.GetLeaveTypeDetails(Id);
    }

    async Task EditLeaveType()
    {
        var response = await LeaveTypeService.UpdateLeaveType(leaveType);

        if (response.Success)
        {
            NavigationManager.NavigateTo("/leavetypes/");
        }

        Message = response.Message;
    }
}
