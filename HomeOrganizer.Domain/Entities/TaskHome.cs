using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Task = HomeOrganizer.Domain.Entities.Task;

namespace HomeOrganizer.Domain.Entities;

[Table("task_home")]
[Index("TaskId", Name = "FK_task_home_task")]
[Index("HomeId", "TaskId", Name = "U_task_home", IsUnique = true)]
public class TaskHome: EntityBase
{
    [Column("home_id")]
    [StringLength(36)]
    public Guid HomeId { get; set; }

    [Column("task_id")]
    [StringLength(36)]
    public Guid TaskId { get; set; }

    [ForeignKey("HomeId")]
    [InverseProperty("TaskHomes")]
    public virtual Home Home { get; set; } = null!;

    [ForeignKey("TaskId")]
    [InverseProperty("TaskHomes")]
    public virtual Task Task { get; set; } = null!;
}
