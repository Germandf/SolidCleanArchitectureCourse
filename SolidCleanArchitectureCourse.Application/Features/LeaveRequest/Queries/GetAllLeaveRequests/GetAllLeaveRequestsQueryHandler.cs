using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public class GetAllLeaveRequestsQueryHandler : IRequestHandler<GetAllLeaveRequestsQuery, List<LeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IUserService _userService;

    public GetAllLeaveRequestsQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _userService = userService;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetAllLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = new List<Domain.LeaveRequest>();
        var leaveRequestDtos = new List<LeaveRequestDto>();

        if (request.IsLoggedInUser)
        {
            var userId = _userService.UserId;
            leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);
            var employee = await _userService.GetEmployee(userId);
            leaveRequestDtos = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
            
            foreach (var leaveRequestDto in leaveRequestDtos)
            {
                leaveRequestDto.Employee = employee;
            }
        }
        else
        {
            leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            leaveRequestDtos = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
            
            foreach (var leaveRequestDto in leaveRequestDtos)
            {
                leaveRequestDto.Employee = await _userService.GetEmployee(leaveRequestDto.RequestingEmployeeId);
            }
        }

        return leaveRequestDtos;
    }
}
