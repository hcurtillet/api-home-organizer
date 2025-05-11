using System.Linq.Expressions;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Application.Common.Interfaces.Dao;

public interface IBaseDao<TEntity> where TEntity : EntityBase
{
    TEntity GetById(Guid id);
    IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> GetAll();
    TEntity Add(TEntity entity);
    TEntity Add(TEntity entity, bool save);
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities, bool save);
    TEntity Update(TEntity entity);
    TEntity Update(TEntity entity, bool save);
    IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
    IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities, bool save);
    void Delete(Guid id);
    void Delete(Guid id, bool save);
    void Delete(TEntity entity);
    void Delete(TEntity entity, bool save);
    void DeleteRange(IEnumerable<TEntity> entities);
    void DeleteRange(IEnumerable<TEntity> entities, bool save);
    int SaveChanges();
}