using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public class LeaveRequestDto
{
    public string RequestingEmployeeId { get; set; } = "";
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool? Approved { get; set; }
}
