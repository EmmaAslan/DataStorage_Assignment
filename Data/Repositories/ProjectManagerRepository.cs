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
        var result = await context.ProjectManagers.ToListAsync();
        return result;
    }

    public async Task<ProjectManagerEntity> GetByIdAsync(int id)
    {
        var entity = await context.ProjectManagers.FindAsync(id);
        return entity ?? null!;
    }

    public async Task<ProjectManagerEntity> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        var entity = await context.ProjectManagers.FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }

    public async Task<ProjectManagerEntity> UpdateAsync(ProjectManagerEntity entity)
    {
        context.ProjectManagers.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Find the entity by the id
        var entity = await context.ProjectManagers.FindAsync(id);

        // If the entity is null, it means that the entity was not found
        if (entity is null)
        {
            return false;
        }

        // Remove the entity from the context
        context.ProjectManagers.Remove(entity);

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
