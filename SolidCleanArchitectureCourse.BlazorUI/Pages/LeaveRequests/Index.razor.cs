using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveRequests;

public partial class Index
{
    [Inject]
    ILeaveRequestService LeaveRequestService { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    public AdminLeaveRequestViewVm Model { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await LeaveRequestService.GetAdminLeaveRequestList();
    }

    void GoToDetails(int id)
    {
        NavigationManager.NavigateTo($"/leaverequests/details/{id}");
    }
}
