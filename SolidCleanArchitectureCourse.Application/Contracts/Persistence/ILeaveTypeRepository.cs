using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);
}
 