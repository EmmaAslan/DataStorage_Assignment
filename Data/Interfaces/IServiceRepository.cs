using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IServiceRepository
    {
        Task<ServiceEntity> CreateAsync(ServiceEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ServiceEntity>> GetAllAsync();
        Task<ServiceEntity> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression);
        Task<ServiceEntity> GetByIdAsync(int id);
        Task<ServiceEntity> UpdateAsync(ServiceEntity entity);
    }
}