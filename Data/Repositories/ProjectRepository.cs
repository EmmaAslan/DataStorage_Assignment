using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : IProjectRepository
{
    public async Task<ProjectEntity> CreateAsync(ProjectEntity entity)
    {
        await context.Projects.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await context.Projects.ToListAsync();
    }

    public async Task<ProjectEntity> GetByIdAsync(int id)
    {
        var entity = await context.Projects.FindAsync(id);
        return entity ?? null!;
    }

    public async Task<ProjectEntity> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        // GetByNameAsync(x => x.ProjectName == "ProjectName");
        // GetByNameAsync(x => x.ProjectManager == "ProjectManager");
        var entity = await context.Projects.FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }

    public async Task<ProjectEntity> UpdateAsync(ProjectEntity entity)
    {
        context.Projects.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Projects.FindAsync(id);

        if (entity is null)
        {
            return;
        }
        context.Projects.Remove(entity);

        await context.SaveChangesAsync();
    }


}
