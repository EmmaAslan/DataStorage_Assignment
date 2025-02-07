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
        return new CustomerModel
        {
            CustomerName = entity.CustomerName,
            Email = entity.Email,
            Phone = entity.Phone
        };
    }
}
