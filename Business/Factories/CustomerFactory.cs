using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity CreateCustomer(CustomerRegistrationForm dto)
    {
        return new CustomerEntity
        {
            CustomerName = dto.CustomerName,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }

    public static CustomerModel CreateCustomer(CustomerEntity entity)
    {
        // Får null när jag skapar Project
        if (entity == null)
            return null!;

        return new CustomerModel
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            Email = entity.Email,
            Phone = entity.Phone
        };
    }

    public static CustomerEntity CreateCustomer(CustomerModel model)
    {
        return new CustomerEntity
        {
            Id = model.Id,
            CustomerName = model.CustomerName,
            Email = model.Email,
            Phone = model.Phone
        };
    }
}
