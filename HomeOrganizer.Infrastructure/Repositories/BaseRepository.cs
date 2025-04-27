using System.Linq.Expressions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeOrganizer.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly IHomeOrganizerContext _context;
    
    public BaseRepository(IHomeOrganizerContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public TEntity GetById(int id)
    {
        return _dbSet.Find(id) ?? throw new KeyNotFoundException($"Entity with id {id} not found.");
    }

    public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }

        _dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        var entityBases = entities.ToList();
        if (entities == null || entityBases.Count == 0)
        {
            throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty.");
        }

        _dbSet.AddRange(entityBases.ToArray());
    }

    public void Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }

        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        var entityBases = entities.ToList();
        if (entities == null || entityBases.Count == 0)
        {
            throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty.");
        }

        _dbSet.UpdateRange(entityBases.ToArray());
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        _dbSet.Remove(entity);
    }

    public void Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }

        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        var entityBases = entities.ToList();
        if (entities == null || entityBases.Count == 0)
        {
            throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty.");
        }

        _dbSet.RemoveRange(entityBases.ToArray());
    }
}