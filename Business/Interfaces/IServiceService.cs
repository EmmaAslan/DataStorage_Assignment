using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceModel> CreateAsync(ServiceRegistrationForm dto);
        Task<IEnumerable<ServiceModel>> GetAllAsync();
        Task<ServiceModel> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression);
        Task<ServiceModel> GetByIdAsync(int id);
        Task<ServiceModel> UpdateAsync(ServiceModel model);
        Task<bool> DeleteAsync(int id);
    }
}