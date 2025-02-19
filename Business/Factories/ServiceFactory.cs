using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{
    public static ServiceEntity CreateService(ServiceRegistrationForm dto)
    {
        return new ServiceEntity
        {
            ServiceName = dto.ServiceName,
            Price = dto.Price
        };
    }

    public static ServiceModel CreateService(ServiceEntity entity)
    {
        if (entity == null)
            return null!;

        return new ServiceModel
        {
            Id = entity.Id,
            ServiceName = entity.ServiceName,
            Price = entity.Price
        };
    }

     public static ServiceEntity CreateService(ServiceModel model)
    {
        return new ServiceEntity
        {
            Id = model.Id,
            ServiceName = model.ServiceName,
            Price = (int)model.Price
        };
    } 
}
