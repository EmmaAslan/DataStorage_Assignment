using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IProjectManagerRepository
    {
        Task<ProjectManagerEntity> CreateAsync(ProjectManagerEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProjectManagerEntity>> GetAllAsync();
        Task<ProjectManagerEntity> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression);
        Task<ProjectManagerEntity> GetByIdAsync(int id);
        Task<ProjectManagerEntity> UpdateAsync(ProjectManagerEntity entity);
    }
}