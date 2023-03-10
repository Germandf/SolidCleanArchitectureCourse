using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;

namespace SolidCleanArchitectureCourse.BlazorUI.Contracts;

public interface ILeaveRequestService
{
    Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList();
    Task<EmployeeLeaveRequestViewVm> GetUserLeaveRequests();
    Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVm leaveRequest);
    Task<LeaveRequestVm> GetLeaveRequest(int id);
    Task DeleteLeaveRequest(int id);
    Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved);
    Task<Response<Guid>> CancelLeaveRequest(int id);
}
