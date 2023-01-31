using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
