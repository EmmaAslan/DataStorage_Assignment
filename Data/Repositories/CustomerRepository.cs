using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
        await context.Customers.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity> GetByIdAsync(int id)
    {
        var entity = await context.Customers.FindAsync(id);
        return entity ?? null!;
    }

    public async Task<CustomerEntity> GetByAnyAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        // GetByAnyAsync(x => x.CustomerName == "CustomerName");
        // GetByAnyAsync(x => x.Email == "Email");
        // GetByAnyAsync(x => x.Phone == "Phone");
        var entity = await context.Customers.FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }

    public async Task<CustomerEntity> UpdateAsync(CustomerEntity entity)
    {
        // Update the entity in the context
        context.Customers.Update(entity);

        // Save the changes to the database
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Find the entity by the id
        var entity = await context.Customers.FindAsync(id);

        // If the entity is null, it means that the entity was not found
        if (entity is null)
        {
            return false;
        }

        // Remove the entity from the context
        context.Customers.Remove(entity);

        // Save the changes to the database
        var deleted = await context.SaveChangesAsync();

        // If the deleted is 0, it means that the entity was not deleted
        if (deleted == 0)
        {
            return false;
        }
        
        return true; 
    }
}
