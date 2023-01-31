using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.CreateLeaveType;

public record CreateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<int>;
