using HomeOrganizer.Domain.Common;
using HomeOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Task = HomeOrganizer.Domain.Entities.Task;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface IHomeOrganizerContext
{
     DbSet<Home> Homes { get; set; }

    DbSet<Task> Tasks { get; set; }

    DbSet<TaskHome> TaskHomes { get; set; }

    DbSet<TaskUserAccount> TaskUserAccounts { get; set; }

    DbSet<UserAccount> UserAccounts { get; set; }

    DbSet<UserAccountHome> UserAccountHomes { get; set; }

    DbSet<T> Set<T>() where T : EntityBase;
    
    DatabaseFacade Database { get; }
    
    int SaveChanges();
}