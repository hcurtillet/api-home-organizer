using System;
using System.Collections.Generic;
using System.Reflection;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Common;
using HomeOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = HomeOrganizer.Domain.Entities.Task; 

namespace HomeOrganizer.Infrastructure.Context;

public partial class HomeOrganizerContext : DbContext, IHomeOrganizerContext
{
    public HomeOrganizerContext()
    {
    }

    public HomeOrganizerContext(DbContextOptions<HomeOrganizerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Home> Homes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }
    
    public virtual DbSet<TaskUserAccount> TaskUserAccounts { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserAccountHome> UserAccountHomes { get; set; }
    
    public new DbSet<T> Set<T>() where T : EntityBase
    {
        return base.Set<T>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Home>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedAt).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            
            entity.HasOne(d => d.Home).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_home");
            
            entity.Property(e => e.Description).IsFixedLength();
            entity.Property(e => e.DueDt).IsFixedLength();
            entity.Property(e => e.DueTm).IsFixedLength();
            entity.Property(e => e.CreatedAt).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedAt).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<TaskUserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedAt).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();

            entity.HasOne(d => d.Task).WithMany(p => p.TaskUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_user_account_task");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.TaskUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_user_account_user_account");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedAt).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<UserAccountHome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedAt).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();

            entity.HasOne(d => d.Home).WithMany(p => p.UserAccountHomes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_user_account_home_home");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.UserAccountHomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_account_home_user_account");
        });
        
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
