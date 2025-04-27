using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Common;
using HomeOrganizer.Infrastructure.Context;
using HomeOrganizer.Infrastructure.Repositories;

namespace HomeOrganizer.Infrastructure.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly IHomeOrganizerContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(IHomeOrganizerContext context)
    {
        _context = context;
    }

    public IHomeOrganizerContext Context => _context;

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _context.SaveChanges();
        _context.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }
    
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
    
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
    {
        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            var repository = new BaseRepository<TEntity>(_context);
            _repositories.Add(type, repository);
        }

        return (IRepository<TEntity>)_repositories[type];
    }
}