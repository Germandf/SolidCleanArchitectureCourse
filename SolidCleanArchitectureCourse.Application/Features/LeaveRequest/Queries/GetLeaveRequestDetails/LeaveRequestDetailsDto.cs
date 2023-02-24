using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using SolidCleanArchitectureCourse.Application.Models.Identity;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class LeaveRequestDetailsDto
{
    public int Id { get; set; }
    public Employee Employee { get; set; } = null!;
    public string RequestingEmployeeId { get; set; } = "";
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestComments { get; set; } = "";
}
