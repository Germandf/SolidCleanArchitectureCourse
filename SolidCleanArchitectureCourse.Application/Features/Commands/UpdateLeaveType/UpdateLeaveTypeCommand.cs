using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.Commands.UpdateLeaveType;

public record UpdateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<Unit>;
