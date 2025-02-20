using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ServiceService(IServiceRepository _repository) : IServiceService
{
    public async Task CreateAsync(ServiceRegistrationForm dto)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var serviceEntity = ServiceFactory.CreateService(dto);
            await _repository.AddAsync(serviceEntity);
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
    public async Task<IEnumerable<ServiceModel>> GetAllAsync()
    {
        var serviceEntities = await _repository.GetAsync();
        if (serviceEntities is null)
        {
            return null!;
        }
        return serviceEntities.Select(ServiceFactory.CreateService).ToList();
    }
    public async Task<ServiceModel> GetByIdAsync(int id)
    {
        var serviceEntity = await _repository.GetAsync(i => i.Id == id);
        if (serviceEntity is null)
        {
            return null!;
        }
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var serviceEntity = await _repository.GetAsync(expression);
        if (serviceEntity is null)
        {
            return null!;
        }
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> UpdateAsync(ServiceModel model)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var entity = ServiceFactory.CreateService(model);
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

        return ServiceFactory.CreateService(x);
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
