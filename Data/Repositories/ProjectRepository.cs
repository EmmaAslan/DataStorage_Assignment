using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{

    /*public override async Task AddAsync(ProjectEntity entity)
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
    }*/

    public async override Task<IEnumerable<ProjectEntity>> GetAsync()
    {
        var result = await context.Projects
            .Include(x => x.StatusType)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Service)
            .ToListAsync();
        return result;
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
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

    //private IQueryable<ProjectEntity> IncludeProperties()
    //{
    //    return _dbSet
    //    .Include(x => x.StatusType)
    //    .Include(x => x.Customer)
    //    .Include(x => x.ProjectManager)
    //    .Include(x => x.Service);
    //}

    /*public override async Task<ProjectEntity?> CreateAsync(ProjectEntity entity)
    {
        try
        {
            await BeginTransactionAsync();
            await AddAsync(entity);
            await SaveAsync();
            await CommitTransactionAsync();

            return await IncludeProperties()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        catch
        {
            await RollbackTransactionAsync();
            return null!;
        }
    }

    public override async Task<IEnumerable<ProjectEntity>> GetAsync()
    {
        return await IncludeProperties().ToListAsync();
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await IncludeProperties()
            .FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await GetAsync();
    }

    public async Task<ProjectEntity> GetByIdAsync(int id)
    {
        var entity = await GetAsync(x => x.Id == id);
        return entity ?? null!;
    }

    public async Task<ProjectEntity> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await GetAsync(expression);
        return entity ?? null!;
    }

    public async Task<ProjectEntity?> UpdateAsync(ProjectEntity entity)
    {
        try
        {
            await BeginTransactionAsync();
            Update(entity);
            await SaveAsync();
            await CommitTransactionAsync();
            return await GetAsync(x => x.Id == entity.Id);
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            await BeginTransactionAsync();
            var entity = await GetAsync(x => x.Id == id);
            if (entity is null)
            {
                await RollbackTransactionAsync();
                return false;
            }

            Remove(entity);
            var result = await SaveAsync();
            await CommitTransactionAsync();
            return result > 0;
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }
    */
    /* public async Task<ProjectEntity> CreateAsync(ProjectEntity entity)
    {
        await AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    } */

    /* public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
     {
         return await _dbSet.ToListAsync();
     }*/

    /*public async Task<ProjectEntity> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity ?? null!;
    }*/

    /* public async Task<ProjectEntity> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        return entity ?? null!;
    }*/


    /* public async Task<ProjectEntity> UpdateAsync(ProjectEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }*/

    /* 
     public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            return false;
        }
        _dbSet.Remove(entity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    } */


}

/* public class ProjectRepository(DataContext context) : IProjectRepository
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
*/