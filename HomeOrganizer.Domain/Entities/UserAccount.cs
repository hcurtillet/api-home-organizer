using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Entities;

[Table("user_account")]
public class UserAccount: EntityBase
{
    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;
    [Column("firstname")]
    [StringLength(50)]
    public string Firstname { get; set; } = string.Empty;

    [Column("lastname")]
    [StringLength(50)]
    public string Lastname { get; set; } = string.Empty;
    
    [InverseProperty("UserAccount")]
    public virtual ICollection<TaskUserAccount> TaskUserAccounts { get; set; } = new List<TaskUserAccount>();

    [InverseProperty("UserAccount")]
    public virtual ICollection<UserAccountHome> UserAccountHomes { get; set; } = new List<UserAccountHome>();
}
