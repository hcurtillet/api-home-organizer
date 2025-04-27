using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Entities;

[Table("task")]
public class Task: EntityBase
{

    [Column("description")]
    [StringLength(2024)]
    public string Description { get; set; } = null!;

    [Column("task_status")]
    public int TaskStatus { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<TaskHome> TaskHomes { get; set; } = new List<TaskHome>();

    [InverseProperty("Task")]
    public virtual ICollection<TaskUserAccount> TaskUserAccounts { get; set; } = new List<TaskUserAccount>();
}
