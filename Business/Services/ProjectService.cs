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
    public async Task CreateAsync(ProjectRegistrationForm dto)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var projectEntity = ProjectFactory.CreateProject(dto);
            await _repository.AddAsync(projectEntity);
            var result = await _repository.SaveAsync();
            if (result == 0)
            {
                await _repository.RollbackTransactionAsync();
            }
            await _repository.CommitTransactionAsync();
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
        }
    }
    public async Task<IEnumerable<ProjectModel>> GetAllAsync()
    {
        var projectEntities = await _repository.GetAsync();
        if (projectEntities is null)
        {
            return null!;
        }
        return projectEntities.Select(ProjectFactory.CreateProject).ToList();
    }
    public async Task<ProjectModel> GetByIdAsync(int id)
    {
        var projectEntity = await _repository.GetAsync(i => i.Id == id);
        if (projectEntity is null)
        {
            return null!;
        }
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> GetByAnyAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var projectEntity = await _repository.GetAsync(expression);
        if (projectEntity is null)
        {
            return null!;
        }
        return ProjectFactory.CreateProject(projectEntity);
    }
    public async Task<ProjectModel> UpdateAsync(ProjectModel model)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var entity = ProjectFactory.CreateProject(model);
            _repository.Update(entity);

            var result = await _repository.SaveAsync();
            if (result == 0)
            {
                await _repository.RollbackTransactionAsync();
                return null!;
            }
            await _repository.CommitTransactionAsync();
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
        }

        var x = await _repository.GetAsync(i => i.Id == model.Id);
        if (x is null)
            return null!;

        return ProjectFactory.CreateProject(x);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var entity = await _repository.GetAsync(i => i.Id == id);
            if (entity is null)
            {
                await _repository.RollbackTransactionAsync();
                return false;
            }

            _repository.Remove(entity);
            var result = await _repository.SaveAsync();
            if (result == 0)
            {
                await _repository.RollbackTransactionAsync();
                return false;
            }
            await _repository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _repository.RollbackTransactionAsync();
            return false;

        }
    }
}