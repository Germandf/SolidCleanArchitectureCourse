using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveRequests;

public partial class EmployeeIndex
{
    [Inject]
    ILeaveRequestService LeaveRequestService { get; set; } = null!;

    [Inject]
    IJSRuntime Js { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    public EmployeeLeaveRequestViewVm Model { get; set; } = new();
    public string Message { get; set; } = string.Empty;

    protected async override Task OnInitializedAsync()
    {
        Model = await LeaveRequestService.GetUserLeaveRequests();
    }

    async Task CancelRequestAsync(int id)
    {
        var confirm = await Js.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");

        if (confirm)
        {
            var response = await LeaveRequestService.CancelLeaveRequest(id);

            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }
    }
}
