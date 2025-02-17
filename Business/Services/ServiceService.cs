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
    public async Task<ServiceModel> CreateAsync(ServiceRegistrationForm dto)
    {
        var serviceEntity = ServiceFactory.CreateService(dto);
        var createdServiceEntity = await _repository.CreateAsync(serviceEntity);
        return ServiceFactory.CreateService(createdServiceEntity);
    }
    public async Task<IEnumerable<ServiceModel>> GetAllAsync()
    {
        var serviceEntities = await _repository.GetAllAsync();
        if (serviceEntities is null)
        {
            return null!;
        }
        return serviceEntities.Select(ServiceFactory.CreateService).ToList();
    }
    public async Task<ServiceModel> GetByIdAsync(int id)
    {
        var serviceEntity = await _repository.GetByIdAsync(id);
        if (serviceEntity is null)
        {
            return null!;
        }
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var serviceEntity = await _repository.GetByAnyAsync(expression);
        if (serviceEntity is null)
        {
            return null!;
        }
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> UpdateAsync(ServiceModel model)
    {
        // Create a new ServiceEntity from the ServiceModel
        var entity = ServiceFactory.CreateService(model);

        // Update the entity in the database
        var updatedServiceEntity = await _repository.UpdateAsync(entity);
        if (updatedServiceEntity is null)
        {
            return null!;
        }

        // Create a new ServiceModel from the updated ServiceEntity
        var updatedServiceModel = ServiceFactory.CreateService(updatedServiceEntity);
        
        return updatedServiceModel;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(id);
        return result;
    }
}
