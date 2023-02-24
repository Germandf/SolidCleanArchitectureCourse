using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveAllocations;

namespace SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;

public class EmployeeLeaveRequestViewVm
{
    public List<LeaveAllocationVm> LeaveAllocations { get; set; } = new();

    public List<LeaveRequestVm> LeaveRequests { get; set; } = new();
}
