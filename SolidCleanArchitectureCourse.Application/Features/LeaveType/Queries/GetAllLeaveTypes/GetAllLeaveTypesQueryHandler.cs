using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetAllLeaveTypesQueryHandler> _logger;

    public GetAllLeaveTypesQueryHandler(
        IMapper mapper, 
        ILeaveTypeRepository leaveTypeRepository, 
        IAppLogger<GetAllLeaveTypesQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAsync();
        var leaveTypeDtos = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        _logger.LogInformation("Leave types were retrieved successfully");
        return leaveTypeDtos;
    }
}
