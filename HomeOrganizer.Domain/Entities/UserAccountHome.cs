using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeOrganizer.Domain.Common;
using HomeOrganizer.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace HomeOrganizer.Domain.Entities;

[Table("user_account_home")]
[Index("HomeId", Name = "FK_user_account_home_home")]
[Index("UserAccountId", "HomeId", Name = "U_user_account_home", IsUnique = true)]
public  class UserAccountHome: EntityBase
{
    [Column("user_account_id")]
    [StringLength(36)]
    public Guid UserAccountId { get; set; }

    [Column("home_id")]
    [StringLength(36)]
    public Guid HomeId { get; set; }

    [Column("role")]
    public UserAccountHomeRole Role { get; set; }

    [ForeignKey("HomeId")]
    [InverseProperty("UserAccountHomes")]
    public virtual Home Home { get; set; } = null!;

    [ForeignKey("UserAccountId")]
    [InverseProperty("UserAccountHomes")]
    public virtual UserAccount UserAccount { get; set; } = null!;
}
