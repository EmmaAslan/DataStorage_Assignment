using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<ProjectModel> CreateAsync(ProjectRegistrationForm dto);
    Task<IEnumerable<ProjectModel>> GetAllAsync();
    Task<ProjectModel> GetByIdAsync(int id);
    Task<ProjectModel> UpdateAsync(ProjectModel model);
    Task<bool> DeleteAsync(int id);
}