using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeOrganizer.Domain.Entities;

[Table("task_user_account")]
[Index("TaskId", Name = "FK_task_user_account_task")]
[Index("UserAccountId", "TaskId", Name = "U_task_user_account", IsUnique = true)]
public class TaskUserAccount: EntityBase
{
    [Column("user_account_id")]
    [StringLength(36)]
    public Guid UserAccountId { get; set; }

    [Column("task_id")]
    [StringLength(36)]
    public Guid TaskId { get; set; }

    [ForeignKey("TaskId")]
    [InverseProperty("TaskUserAccounts")]
    public virtual Task Task { get; set; } = null!;

    [ForeignKey("UserAccountId")]
    [InverseProperty("TaskUserAccounts")]
    public virtual UserAccount UserAccount { get; set; } = null!;
}
