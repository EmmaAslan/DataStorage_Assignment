using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
}

/*
public class ServiceRepository(DataContext context) : IServiceRepository
{
    public async Task<ServiceEntity> CreateAsync(ServiceEntity entity)
    {
        await context.Services.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<ServiceEntity>> GetAllAsync()
    {
        return await context.Services.ToListAsync();
    }

    public async Task<ServiceEntity> GetByIdAsync(int id)
    {
        var entity = await context.Services.FindAsync(id);
        return entity ?? null!;
    }

    public async Task<ServiceEntity> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var entity = await context.Services.FirstOrDefaultAsync(expression);

        return entity ?? null!;

    }

    public async Task<ServiceEntity> UpdateAsync(ServiceEntity entity)
    {
        context.Services.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Find the entity by the id
        var entity = await context.Services.FindAsync(id);

        // If the entity is null, it means that the entity was not found
        if (entity is null)
        {
            return false;
        }

        // Remove the entity from the context
        context.Services.Remove(entity);

        // Save the changes to the database
        var deleted = await context.SaveChangesAsync();

        // If the deleted is 0, it means that the entity was not deleted
        if (deleted == 0)
        {
            return false;
        }

        return true;
    }
}

*/
