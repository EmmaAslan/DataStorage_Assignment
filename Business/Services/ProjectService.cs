using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository _repository) : IProjectService
{
    public async Task<ProjectModel> CreateAsync(ProjectRegistrationForm dto)
    {
        var projectEntity = ProjectFactory.CreateProject(dto);
        var createdProjectEntity = await _repository.CreateAsync(projectEntity);
        return ProjectFactory.CreateProject(createdProjectEntity);
    }
    public async Task<IEnumerable<ProjectModel>> GetAllAsync()
    {
        var projectEntities = await _repository.GetAllAsync();
        if (projectEntities is null)
        {
            return null!;
        }
        var models = projectEntities.Select(ProjectFactory.CreateProject).ToList();
        return models;
    }
    public async Task<ProjectModel> GetByIdAsync(int id)
    {
        var projectEntity = await _repository.GetByIdAsync(id);
        if (projectEntity is null)
        {
            return null!;
        }
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var projectEntity = await _repository.GetByAnyAsync(expression);
        if (projectEntity is null)
        {
            return null!;
        }
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> UpdateAsync(ProjectModel model)
    {
        // Create a new ProjectEntity from the ProjectModel
        var entity = ProjectFactory.CreateProject(model);

        // Update the entity in the database
        var updatedProjectEntity = await _repository.UpdateAsync(entity);
        if (updatedProjectEntity is null)
        {
            return null!;
        }
        var updatedProjectModel = ProjectFactory.CreateProject(updatedProjectEntity);
        
        return updatedProjectModel;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(id);
        return result;
    }
}