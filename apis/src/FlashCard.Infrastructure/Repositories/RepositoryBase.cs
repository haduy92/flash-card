using System.Linq.Expressions;
using FlashCard.Application.Interfaces.Persistence;
using FlashCard.Domain.Entities;
using FlashCard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlashCard.Infrastructure.Repositories;

/// <summary>
/// Base class to implement <see cref="IRepository{TEntity,TPrimaryKey}"/>.
/// It implements some methods in most simple way.
/// </summary>
/// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
/// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _db;

    protected RepositoryBase(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _db = dbContext.Set<TEntity>();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _db.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TPrimaryKey id)
    {
        var entity = _db.Find(id);
        if (entity != null)
        {
            _db.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _db.AsQueryable();
        if (includes != null)
        {
            query = includes.Aggregate(query,
                      (current, include) => current.Include(include));
        }
        return query;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await GetAll().ToListAsync();
    }

    public Task<TEntity?> GetAsync(TPrimaryKey id)
    {
        var entity = _db.Find(id);
        return Task.FromResult(entity);
    }

    public Task<TEntity> InsertAsync(TEntity entity)
    {
        _db.Add(entity);
        _dbContext.SaveChanges();
        return Task.FromResult(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _db.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
