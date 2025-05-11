using System.Data.Entity.Infrastructure.Design;
using System.Linq.Expressions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Infrastructure.Dao;

public abstract class BaseDao<TEntity>: IBaseDao<TEntity> where TEntity : EntityBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IRepository<TEntity> _repository;

    protected BaseDao(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GetRepository<TEntity>();
    }

    public TEntity GetById(Guid id)
    {
        return _repository.GetById(id);
    }
    
    public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return _repository.GetByCondition(predicate);
    }
    
    public IEnumerable<TEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public TEntity Add(TEntity entity) => Add(entity, true);
    public TEntity Add(TEntity entity, bool save)
    {
        _repository.Add(entity);
        if (save)
        {
            SaveChanges();
        }

        return entity;
    }

    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities) => AddRange(entities, true);
    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities, bool save)
    {
        _repository.AddRange(entities);
        if (save)
        {
            SaveChanges();
        }

        return entities;
    }

    public TEntity Update(TEntity entity) => Update(entity, true);
    public TEntity Update(TEntity entity, bool save)
    {
        _repository.Update(entity);
        if (save)
        {
            SaveChanges();
        }

        return entity;
    }

    public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities) => UpdateRange(entities, true);
    public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities, bool save)
    {
        _repository.UpdateRange(entities);
        if (save)
        {
            SaveChanges();
        }

        return entities;
    }

    public void Delete(Guid id) => Delete(id, true);
    public void Delete(Guid id, bool save)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
        if (save)
        {
            SaveChanges();
        }
    }

    public void Delete(TEntity entity) => Delete(entity, true);
    public void Delete(TEntity entity, bool save)
    {
        _repository.Delete(entity);
        if (save)
        {
            SaveChanges();
        }
    }

    public void DeleteRange(IEnumerable<TEntity> entities) => DeleteRange(entities, true);
    public void DeleteRange(IEnumerable<TEntity> entities, bool save)
    {
        _repository.DeleteRange(entities);
        if (save)
        {
            SaveChanges();
        }
    }
    
    public int SaveChanges()
    {
        return _unitOfWork.SaveChanges();
    }
}