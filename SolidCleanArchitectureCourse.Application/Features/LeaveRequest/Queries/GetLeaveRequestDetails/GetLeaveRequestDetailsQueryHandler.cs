using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IUserService _userService;

    public GetLeaveRequestDetailsQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _userService = userService;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
        var leaveRequestDto = _mapper.Map<LeaveRequestDetailsDto>(leaveRequest);
        leaveRequestDto.Employee = await _userService.GetEmployee(leaveRequestDto.RequestingEmployeeId);
        return leaveRequestDto;
    }
}
