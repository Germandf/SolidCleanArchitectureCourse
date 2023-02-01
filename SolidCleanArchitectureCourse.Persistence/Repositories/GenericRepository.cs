using Microsoft.EntityFrameworkCore;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Domain.Common;
using SolidCleanArchitectureCourse.Persistence.DatabaseContexts;

namespace SolidCleanArchitectureCourse.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DatabaseContext _context;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
