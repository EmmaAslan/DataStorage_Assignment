using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository _repository)
{
   
    public async Task<CustomerModel> CreateAsync(CustomerRegistrationForm dto)
    {
        var customerEntity = CustomerFactory.CreateCustomer(dto);
        var createdCustomerEntity = await _repository.CreateAsync(customerEntity);
        return CustomerFactory.CreateCustomer(createdCustomerEntity);
    }

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        var customerEntities = await _repository.GetAllAsync();
        return customerEntities.Select(CustomerFactory.CreateCustomer).ToList();
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        var customerEntity = await _repository.GetByIdAsync(id);
        return CustomerFactory.CreateCustomer(customerEntity);
    }

    public async Task<CustomerModel> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var customerEntity = await _repository.GetByAnyAsync(expression);
        return CustomerFactory.CreateCustomer(customerEntity);
    }

    public async Task<CustomerModel> UpdateAsync(CustomerEntity entity)
    {
        var updatedCustomerEntity = await _repository.UpdateAsync(entity);
        return CustomerFactory.CreateCustomer(updatedCustomerEntity);
    }
}

