using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ServiceService(IServiceRepository _repository)
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
        return serviceEntities.Select(ServiceFactory.CreateService).ToList();
    }
    public async Task<ServiceModel> GetByIdAsync(int id)
    {
        var serviceEntity = await _repository.GetByIdAsync(id);
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> GetByAnyAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var serviceEntity = await _repository.GetByAnyAsync(expression);
        return ServiceFactory.CreateService(serviceEntity);
    }
    public async Task<ServiceModel> UpdateAsync(ServiceEntity entity)
    {
        var updatedServiceEntity = await _repository.UpdateAsync(entity);
        return ServiceFactory.CreateService(updatedServiceEntity);
    }
}
