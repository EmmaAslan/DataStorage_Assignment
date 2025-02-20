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
    public async Task CreateAsync(CustomerRegistrationForm dto)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var customerEntity = CustomerFactory.CreateCustomer(dto);
            await _repository.AddAsync(customerEntity);
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

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        var customerEntities = await _repository.GetAsync();
        if (customerEntities is null)
        {
            return null!;
        }
        return customerEntities.Select(CustomerFactory.CreateCustomer).ToList();
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        var customerEntity = await _repository.GetAsync(i => i.Id == id);
        if (customerEntity is null)
        {
            return null!;
        }
        return CustomerFactory.CreateCustomer(customerEntity);
    }

    public async Task<CustomerModel> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var customerEntity = await _repository.GetAsync(expression);
        if (customerEntity is null)
        {
            return null!;
        }
        return CustomerFactory.CreateCustomer(customerEntity);
    }


    public async Task<CustomerModel> UpdateAsync(CustomerModel model)
    {
        await _repository.BeginTransactionAsync();

        try
        {
            var entity = CustomerFactory.CreateCustomer(model);
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

        return CustomerFactory.CreateCustomer(x);
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

