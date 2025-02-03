using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

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
        // GetByNameAsync(x => x.ServiceName == "ServiceName");
        // GetByNameAsync(x => x.Price == "Price");

        var entity = await context.Services.FirstOrDefaultAsync(expression);

        return entity ?? null!;

    }

    public async Task<ServiceEntity> UpdateAsync(ServiceEntity entity)
    {
        context.Services.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Services.FindAsync(id);

        if (entity is null)
        {
            return;
        }
        context.Services.Remove(entity);

        await context.SaveChangesAsync();
    }



}
