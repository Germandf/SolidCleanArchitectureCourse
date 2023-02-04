namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Shared;

public abstract record BaseLeaveRequest(DateTime StartDate, DateTime EndDate, int LeaveTypeId);
