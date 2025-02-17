using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<CustomerModel> CreateAsync(CustomerRegistrationForm dto);
    Task<IEnumerable<CustomerModel>> GetAllAsync();
    Task<CustomerModel> GetByIdAsync(int id);
    Task<CustomerModel> UpdateAsync(CustomerModel model);
    Task<bool> DeleteAsync(int id);
}

