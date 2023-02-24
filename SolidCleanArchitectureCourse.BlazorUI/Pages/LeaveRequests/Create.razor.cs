using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveRequests;

public partial class Create
{
    [Inject]
    ILeaveTypeService LeaveTypeService { get; set; } = null!;

    [Inject]
    ILeaveRequestService LeaveRequestService { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private LeaveRequestVm _leaveRequest { get; set; } = new();
    private List<LeaveTypeVm> _leaveTypeVms { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        _leaveTypeVms = await LeaveTypeService.GetLeaveTypes();
    }

    private async Task HandleValidSubmit()
    {
        await LeaveRequestService.CreateLeaveRequest(_leaveRequest);
        NavigationManager.NavigateTo("/leaverequests");
    }
}
