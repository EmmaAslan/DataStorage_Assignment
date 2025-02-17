using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository _repository) : ICustomerService
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
        if (customerEntities is null)
        {
            return null!;
        }
        return customerEntities.Select(CustomerFactory.CreateCustomer).ToList();
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        var customerEntity = await _repository.GetByIdAsync(id);
        if(customerEntity is null){
            return null!;
        }
        return CustomerFactory.CreateCustomer(customerEntity);
    }

    public async Task<CustomerModel> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var customerEntity = await _repository.GetByAnyAsync(expression);
        if(customerEntity is null)
        {
            return null!;
        }
        return CustomerFactory.CreateCustomer(customerEntity);
    }

   
    public async Task<CustomerModel> UpdateAsync(CustomerModel model)
    {
        // Create a new CustomerEntity from the CustomerModel
        var entity = CustomerFactory.CreateCustomer(model);

        // Update the entity in the database
        var updatedCustomerEntity = await _repository.UpdateAsync(entity);
        if (updatedCustomerEntity is null)
        {
            return null!;
        }

        // Create a new CustomerModel from the updated CustomerEntity
        var updatedCustomerModel = CustomerFactory.CreateCustomer(updatedCustomerEntity);

        return updatedCustomerModel;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(id);
        return result;
    }
}

