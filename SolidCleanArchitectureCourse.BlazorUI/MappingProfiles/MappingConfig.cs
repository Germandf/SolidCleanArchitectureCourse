using AutoMapper;
using SolidCleanArchitectureCourse.BlazorUI.Models.Authentication;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveAllocations;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveRequests;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;

namespace SolidCleanArchitectureCourse.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
	public MappingConfig()
	{
        CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
        CreateMap<LeaveTypeDetailsDto, LeaveTypeVm>().ReverseMap();
        CreateMap<CreateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();
        CreateMap<UpdateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();

        CreateMap<LeaveRequestDto, LeaveRequestVm>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();
        CreateMap<LeaveRequestDetailsDto, LeaveRequestVm>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();
        CreateMap<CreateLeaveRequestCommand, LeaveRequestVm>().ReverseMap();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequestVm>().ReverseMap();

        CreateMap<LeaveAllocationDto, LeaveAllocationVm>().ReverseMap();
        CreateMap<LeaveAllocationDetailsDto, LeaveAllocationVm>().ReverseMap();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocationVm>().ReverseMap();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocationVm>().ReverseMap();
    }
}
