using Microsoft.EntityFrameworkCore;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Domain;
using SolidCleanArchitectureCourse.Persistence.DatabaseContexts;

namespace SolidCleanArchitectureCourse.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(x => x.Name == name);
    }
}
