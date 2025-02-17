using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectEntity> CreateAsync(ProjectEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProjectEntity>> GetAllAsync();
        Task<ProjectEntity> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<ProjectEntity> GetByIdAsync(int id);
        Task<ProjectEntity> UpdateAsync(ProjectEntity entity);
    }
}