using Data.Entities;

namespace Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
}

/* public interface ICustomerRepository
{
    Task<CustomerEntity> CreateAsync(CustomerEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task<CustomerEntity> GetByIdAsync(int id);
    Task<CustomerEntity> UpdateAsync(CustomerEntity entity);
} */