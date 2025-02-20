using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
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

}

