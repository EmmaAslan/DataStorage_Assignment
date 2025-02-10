using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository _repository)
{
    public async Task<ProjectManagerModel> CreateAsync(ProjectManagerRegistrationForm dto)
    {
        var projectManagerEntity = ProjectManagerFactory.CreateProjectManager(dto);
        var createdProjectManagerEntity = await _repository.CreateAsync(projectManagerEntity);
        return ProjectManagerFactory.CreateProjectManager(createdProjectManagerEntity);
    }
    public async Task<IEnumerable<ProjectManagerModel>> GetAllAsync()
    {
        var projectManagerEntities = await _repository.GetAllAsync();
        return projectManagerEntities.Select(ProjectManagerFactory.CreateProjectManager).ToList();
    }
    public async Task<ProjectManagerModel> GetByIdAsync(int id)
    {
        var projectManagerEntity = await _repository.GetByIdAsync(id);
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }
    public async Task<ProjectManagerModel> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        var projectManagerEntity = await _repository.GetByAnyAsync(expression);
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }
    public async Task<ProjectManagerModel> UpdateAsync(ProjectManagerEntity entity)
    {
        var updatedProjectManagerEntity = await _repository.UpdateAsync(entity);
        return ProjectManagerFactory.CreateProjectManager(updatedProjectManagerEntity);
    }
}