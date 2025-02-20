using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private IDbContextTransaction _transaction = null!;

    #region Transaction Management

    public virtual async Task BeginTransactionAsync()
    {
        try
        {
            // Begins a transaction if one does not already exist
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public virtual async Task CommitTransactionAsync()
    {

        try
        {
            // Commits a transaction 
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }   
    }

    public virtual async Task RollbackTransactionAsync()
    {
        try
        {
            // Rolls back a transaction and disposes of it if it exists
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        } 
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        
    }

    #endregion

    #region CRUD

    public virtual async Task AddAsync(TEntity entity)
    {
        try
        {
            // Adds an entity to the context
            await _dbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        try
        {
            // Returns a list of entities
            var entities = await _dbSet.ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        } 
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            // Returns a single entity based on the expression
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public virtual void Update(TEntity entity)
    {
        try
        {
            // Updates an entity in the context
            _dbSet.Update(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public virtual void Remove(TEntity entity)
    {
        try
        {
            // Removes an entity from the context
            _dbSet.Remove(entity);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public virtual async Task<int> SaveAsync()
    {
        try
        {
            // Saves changes to the context
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return 0;
        }
    }

    #endregion

}
