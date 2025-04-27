using System.Linq.Expressions;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    TEntity GetById(int id);
    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Delete(int id);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
}