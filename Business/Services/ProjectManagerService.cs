using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository _repository) : IProjectManagerService
{
    public async Task CreateAsync(ProjectManagerRegistrationForm dto)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var projectManagerEntity = ProjectManagerFactory.CreateProjectManager(dto);
            await _repository.AddAsync(projectManagerEntity);
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

    public async Task<IEnumerable<ProjectManagerModel>> GetAllAsync()
    {
        var projectManagerEntities = await _repository.GetAsync();
        if (projectManagerEntities is null)
        {
            return null!;
        }

        return projectManagerEntities.Select(ProjectManagerFactory.CreateProjectManager);
    }

    public async Task<ProjectManagerModel> GetByIdAsync(int id)
    {
        var projectManagerEntity = await _repository.GetAsync(i => i.Id == id);
        if (projectManagerEntity is null)
        {
            return null!;
        }
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }

    public async Task<ProjectManagerModel> GetByAnyAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        var projectManagerEntity = await _repository.GetAsync(expression);
        if (projectManagerEntity is null)
        {
            return null!;
        }
        return ProjectManagerFactory.CreateProjectManager(projectManagerEntity);
    }

    public async Task<ProjectManagerModel> UpdateAsync(ProjectManagerModel model)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var entity = ProjectManagerFactory.CreateProjectManager(model);
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
        {
            return null!;
        }
        return ProjectManagerFactory.CreateProjectManager(x);
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