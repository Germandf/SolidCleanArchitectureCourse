using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;

namespace SolidCleanArchitectureCourse.BlazorUI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVm>> GetLeaveTypes();
    Task<LeaveTypeVm> GetLeaveTypeDetails(int id);
    Task<Response<Guid>> CreateLeaveType(LeaveTypeVm leaveType);
    Task<Response<Guid>> UpdateLeaveType(LeaveTypeVm leaveType);
    Task<Response<Guid>> DeleteLeaveType(int id);
}
