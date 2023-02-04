using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class LeaveAllocationDetailsDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
