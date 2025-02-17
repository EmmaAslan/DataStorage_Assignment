using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository repository) : IProjectManagerService
{
    private readonly IProjectManagerRepository _repository = repository;

    public async Task<ProjectManagerModel> CreateAsync(ProjectManagerRegistrationForm dto)
    {
        var projectManagerEntity = ProjectManagerFactory.CreateProjectManager(dto);
        var createdProjectManagerEntity = await _repository.CreateAsync(projectManagerEntity);
        return ProjectManagerFactory.CreateProjectManager(createdProjectManagerEntity);
    }
    public async Task<IEnumerable<ProjectManagerModel>> GetAllAsync()
    {
        var projectManagerEntities = await _repository.GetAllAsync();
        if (projectManagerEntities is null)
        {
            return null!;
        }

        return projectManagerEntities.Select(ProjectManagerFactory.CreateProjectManager);
    }
    public async Task<ProjectManagerModel> GetByIdAsync(int id)
    {
        var projectManagerEntity = await _repository.GetByIdAsync(id);
        if (projectManagerEntity is null)
        {
            return null!;
        }
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }
    public async Task<ProjectManagerModel> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        var projectManagerEntity = await _repository.GetByAnyAsync(expression);
        if (projectManagerEntity is null)
        {
            return null!;
        }
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }
    public async Task<ProjectManagerModel> UpdateAsync(ProjectManagerModel model)
    {
        // Create a new ProjectManagerEntity from the ProjectManagerModel
        var entity = ProjectManagerFactory.CreateProjectManager(model);

        // Update the entity in the database
        var updatedProjectManagerEntity = await _repository.UpdateAsync(entity);
        if (updatedProjectManagerEntity is null)
        {
            return null!;
        }
        // Create a new ProjectManagerModel from the updated ProjectManagerEntity
        var updatedProjectManagerModel = ProjectManagerFactory.CreateProjectManager(updatedProjectManagerEntity);
        
        return updatedProjectManagerModel;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(id);
        return result;
    }
}