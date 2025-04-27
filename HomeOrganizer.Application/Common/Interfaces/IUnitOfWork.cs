using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IHomeOrganizerContext Context { get; }
    
    void BeginTransaction();
    
    void CommitTransaction();
    
    void RollbackTransaction();
    int SaveChanges();

    IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;
}