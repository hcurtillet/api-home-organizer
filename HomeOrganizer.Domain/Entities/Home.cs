using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Entities;

[Table("home")]
public class Home: EntityBase
{
   [Column("name")]
   [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Home")]
    public virtual ICollection<TaskHome> TaskHomes { get; set; } = new List<TaskHome>();

    [InverseProperty("Home")]
    public virtual ICollection<UserAccountHome> UserAccountHomes { get; set; } = new List<UserAccountHome>();
}
