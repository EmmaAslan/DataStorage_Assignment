using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectManagerRepository(DataContext context) : IProjectManagerRepository
{
    public async Task<ProjectManagerEntity> CreateAsync(ProjectManagerEntity entity)
    {
        await context.ProjectManagers.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<ProjectManagerEntity>> GetAllAsync()
    {
        return await context.ProjectManagers.ToListAsync();
    }

    public async Task<ProjectManagerEntity> GetByIdAsync(int id)
    {
        var entity = await context.ProjectManagers.FindAsync(id);
        return entity ?? null!;
    }

    public async Task<ProjectManagerEntity> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        // GetByNameAsync(x => x.FirstName == "FirstName");
        // GetByNameAsync(x => x.LastName == "LastName");
        var entity = await context.ProjectManagers.FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }

    public async Task<ProjectManagerEntity> UpdateAsync(ProjectManagerEntity entity)
    {
        context.ProjectManagers.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.ProjectManagers.FindAsync(id);

        if (entity is null)
        {
            return;
        }
        context.ProjectManagers.Remove(entity);

        await context.SaveChangesAsync();
    }






}
