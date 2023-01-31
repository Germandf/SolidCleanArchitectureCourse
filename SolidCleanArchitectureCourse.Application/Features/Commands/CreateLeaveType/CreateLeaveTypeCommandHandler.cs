using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.Application.Features.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToCreate = _mapper.Map<LeaveType>(request);
        var leaveType = await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
        return leaveType.Id;
    }
}
