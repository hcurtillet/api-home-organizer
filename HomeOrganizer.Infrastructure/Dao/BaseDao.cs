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

    public TEntity GetById(int id)
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
    
    public void Add(TEntity entity)
    {
        _repository.Add(entity);
    }
    
    public void AddRange(IEnumerable<TEntity> entities)
    {
        _repository.AddRange(entities);
    }
    
    public void Update(TEntity entity)
    {
        _repository.Update(entity);
    }
    
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _repository.UpdateRange(entities);
    }
    
    public void Delete(int id)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }
    
    public void Delete(TEntity entity)
    {
        _repository.Delete(entity);
    }
    
    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _repository.DeleteRange(entities);
    }
    
    public int SaveChanges()
    {
        return _unitOfWork.SaveChanges();
    }
}