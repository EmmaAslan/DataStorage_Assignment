using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context) : IStatusTypeRepository
{
    public async Task<IEnumerable<StatusTypeEntity>> GetAllAsync()
    {
        return await context.StatusTypes.ToListAsync();
    }
}
