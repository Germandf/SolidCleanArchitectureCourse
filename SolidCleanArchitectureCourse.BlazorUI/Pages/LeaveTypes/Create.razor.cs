using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveTypes;

public partial class Create
{
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    ILeaveTypeService LeaveTypeService { get; set; } = null!;

    [Inject]
    IToastService ToastService { get; set; } = null!;

    public string Message { get; private set; } = "";

    private LeaveTypeVm _leaveType = new();

    async Task CreateLeaveType()
    {
        var response = await LeaveTypeService.CreateLeaveType(_leaveType);

        if(response.Success)
        {
            ToastService.ShowSuccess("Leave Type created Successfully");
            NavigationManager.NavigateTo("/leavetypes/");
        }

        Message = response.Message;
    }
}
