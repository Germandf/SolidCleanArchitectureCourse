using AutoMapper;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.Application.MappingProfiles;

public class LeaveRequestProfile : Profile
{
	public LeaveRequestProfile()
	{
        CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
        CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
}
