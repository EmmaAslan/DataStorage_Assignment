using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectManagerService
    {
        Task CreateAsync(ProjectManagerRegistrationForm dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProjectManagerModel>> GetAllAsync();
        Task<ProjectManagerModel> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression);
        Task<ProjectManagerModel> GetByIdAsync(int id);
        Task<ProjectManagerModel> UpdateAsync(ProjectManagerModel model);
    }
}