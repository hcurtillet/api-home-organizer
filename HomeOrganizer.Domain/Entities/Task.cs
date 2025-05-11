using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;
using TaskStatus = HomeOrganizer.Domain.Enum.TaskStatus;

namespace HomeOrganizer.Domain.Entities;

[Table("task")]
public class Task: EntityBase
{

    [Column("description")]
    [StringLength(2024)]
    public string Description { get; set; } = null!;
    
    [Column("due_dt")]
    [StringLength(8)]
    public string? DueDt { get; set; }
    [Column("due_tm")]
    [StringLength(6)]
    public string? DueTm { get; set; }

    [Column("task_status")]
    public TaskStatus TaskStatus { get; set; }

    [Column("home_id")]
    [StringLength(36)]
    public Guid HomeId { get; set; }
    
    [ForeignKey("HomeId")]
    [InverseProperty("Tasks")]
    public virtual Home Home { get; set; } = null!;

    [InverseProperty("Task")]
    public virtual ICollection<TaskUserAccount> TaskUserAccounts { get; set; } = new List<TaskUserAccount>();
}
