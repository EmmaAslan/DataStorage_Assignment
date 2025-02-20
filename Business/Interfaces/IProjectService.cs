using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(ProjectRegistrationForm dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProjectModel>> GetAllAsync();
        Task<ProjectModel> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<ProjectModel> GetByIdAsync(int id);
        Task<ProjectModel> UpdateAsync(ProjectModel model);
    }
}