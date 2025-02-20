using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IServiceService
    {
        Task CreateAsync(ServiceRegistrationForm dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ServiceModel>> GetAllAsync();
        Task<ServiceModel> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression);
        Task<ServiceModel> GetByIdAsync(int id);
        Task<ServiceModel> UpdateAsync(ServiceModel model);
    }
}