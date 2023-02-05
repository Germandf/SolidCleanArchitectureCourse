using AutoMapper;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;

namespace SolidCleanArchitectureCourse.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
	public MappingConfig()
	{
		CreateMap<LeaveTypeDto, LeaveTypeVm>();
        CreateMap<CreateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();
        CreateMap<UpdateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();
    }
}
