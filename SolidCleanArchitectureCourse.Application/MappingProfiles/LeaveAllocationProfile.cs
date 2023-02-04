using AutoMapper;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
	public LeaveAllocationProfile()
	{
		CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
		CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
		CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
    }
}
