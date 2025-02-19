using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : IProjectRepository
{
    public async Task<ProjectEntity?> CreateAsync(ProjectEntity entity)
    {
        try
        {
            await context.Projects.AddAsync(entity);
            await context.SaveChangesAsync();

            return await context.Projects
                .Include(x => x.StatusType)
                .Include(x => x.Customer)
                .Include(x => x.ProjectManager)
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        catch
        {
            return null!;
        }
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var result =  await context.Projects
            .Include(x => x.StatusType)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Service)
            .ToListAsync();
        return result;
    }

    public async Task<ProjectEntity> GetByIdAsync(int id)
    {
        var entity = await context.Projects
            .Where(x => x.Id == id )
            .Include(x => x.StatusType)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();
        return entity ?? null!;
    }

    public async Task<ProjectEntity> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await context.Projects
            .Where(expression)
            .Include(x => x.StatusType)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();
        
        return entity ?? null!;
    }

    public async Task<ProjectEntity> UpdateAsync(ProjectEntity entity)
    {
        // Update the entity in the context
        context.Projects.Update(entity);

        // Save the changes to the database
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    { 
        // Find the entity by the id
        var entity = await context.Projects.FindAsync(id);

        // If the entity is null, it means that the entity was not found
        if (entity is null)
        {
            return false;
        }

        // Remove the entity from the context
        context.Projects.Remove(entity);

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
