using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task CreateAsync(CustomerRegistrationForm dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<CustomerModel> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<CustomerModel> GetByIdAsync(int id);
        Task<CustomerModel> UpdateAsync(CustomerModel model);
    }
}