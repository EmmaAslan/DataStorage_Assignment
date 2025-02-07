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
        return new ServiceModel
        {
            ServiceName = entity.ServiceName,
            Price = entity.Price
        };
    }
}
