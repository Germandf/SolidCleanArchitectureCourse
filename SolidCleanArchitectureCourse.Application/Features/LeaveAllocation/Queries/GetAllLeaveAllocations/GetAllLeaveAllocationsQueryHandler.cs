using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class GetAllLeaveAllocationsQueryHandler : IRequestHandler<GetAllLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetAllLeaveAllocationsQueryHandler(
        ILeaveAllocationRepository leaveAllocationRepository, 
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetAllLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
        var leaveAllocationDtos = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        return leaveAllocationDtos;
    }
}
