using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailsQueryHandler(
        ILeaveAllocationRepository leaveAllocationRepository, 
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
        var leaveAllocationDetailsDto = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
        return leaveAllocationDetailsDto;
    }
}
