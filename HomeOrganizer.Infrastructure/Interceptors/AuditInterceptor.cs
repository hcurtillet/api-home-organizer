using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HomeOrganizer.Infrastructure.Interceptors;

public class AuditInterceptor: SaveChangesInterceptor
{
    private readonly ICurrentUser _currentUser;

    public AuditInterceptor(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context == null) return result;
        var userId = _currentUser.Id.ToString();
        var now = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        foreach (var entry in eventData.Context.ChangeTracker.Entries<EntityBase>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt ??= now;
                entry.Entity.CreatedBy = userId;
                entry.Entity.UpdatedAt ??= now;
                entry.Entity.UpdatedBy = userId;
            }
            else if (entry.State == EntityState.Modified)
            {
                // Set LastModifiedBy and LastModified properties
                entry.Entity.UpdatedAt = now;
                entry.Entity.UpdatedBy = userId ?? "System";
            }
        }
        return base.SavingChanges(eventData, result);
    }
}