﻿using Microsoft.EntityFrameworkCore;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Domain;
using SolidCleanArchitectureCourse.Persistence.DatabaseContexts;

namespace SolidCleanArchitectureCourse.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(x => 
            x.EmployeeId == userId &&
            x.LeaveTypeId == leaveTypeId &&
            x.Period == period);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Where(x => x.EmployeeId == userId)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);

        return leaveAllocation;
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.FirstOrDefaultAsync(x =>
            x.EmployeeId == userId &&
            x.LeaveTypeId == leaveTypeId);
    }
}
