using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository _repository)
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
        return projectEntities.Select(ProjectFactory.CreateProject).ToList();
    }
    public async Task<ProjectModel> GetByIdAsync(int id)
    {
        var projectEntity = await _repository.GetByIdAsync(id);
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var projectEntity = await _repository.GetByAnyAsync(expression);
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> UpdateAsync(ProjectEntity entity)
    {
        var updatedProjectEntity = await _repository.UpdateAsync(entity);
        return ProjectFactory.CreateProject(updatedProjectEntity);
    }
}