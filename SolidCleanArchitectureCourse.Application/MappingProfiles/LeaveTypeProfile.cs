using AutoMapper;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.CreateLeaveType;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.UpdateLeaveType;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
	public LeaveTypeProfile()
	{
		CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
		CreateMap<LeaveType, LeaveTypeDetailsDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
		CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}
