using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using SolidCleanArchitectureCourse.Application.Models.Identity;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public class LeaveRequestDto
{
    public int Id { get; set; }
    public Employee Employee { get; set; } = null!;
    public string RequestingEmployeeId { get; set; } = "";
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
