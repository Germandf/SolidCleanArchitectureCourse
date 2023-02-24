using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveRequests;

public partial class Details
{
    [Inject]
    ILeaveRequestService LeaveRequestService { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public int Id { get; set; }

    private string _className = "";
    private string _headingText = "";

    public LeaveRequestVm Model { get; private set; } = new();

    protected override void OnInitialized()
    {
        if (Model.Approved == null)
        {
            _className = "warning";
            _headingText = "Pending Approval";
        }
        else if (Model.Approved == true)
        {
            _className = "success";
            _headingText = "Approved";
        }
        else
        {
            _className = "danger";
            _headingText = "Rejected";
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        Model = await LeaveRequestService.GetLeaveRequest(Id);
    }

    async Task ChangeApproval(bool approvalStatus)
    {
        await LeaveRequestService.ApproveLeaveRequest(Id, approvalStatus);
        NavigationManager.NavigateTo("/leaverequests/");
    }
}
