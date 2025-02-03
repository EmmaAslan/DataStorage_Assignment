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
        context.Customers.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Customers.FindAsync(id);

        if (entity is null)
        {
            return;
        }
        context.Customers.Remove(entity);

        await context.SaveChangesAsync();
    }
}
