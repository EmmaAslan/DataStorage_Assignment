using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectManagerService
{
    Task<ProjectManagerModel> CreateAsync(ProjectManagerRegistrationForm dto);
    Task<IEnumerable<ProjectManagerModel>> GetAllAsync();
    Task<ProjectManagerModel> GetByIdAsync(int id);
    Task<ProjectManagerModel> UpdateAsync(ProjectManagerModel model);
    Task<bool> DeleteAsync(int id);
}

