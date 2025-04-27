using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOrganizer.Domain.Common;

public abstract class EntityBase
{
    [Key]
    [Column("id")]
    [StringLength(36)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("created_at")]
    [StringLength(14)]
    public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    
    [Column("created_by")]
    [StringLength(50)]
    public string CreatedBy { get; set; } = "System";
    
    [Column("updated_at")]
    [StringLength(14)]
    public string UpdatedAt { get; set; } = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    
    [Column("updated_by")]
    [StringLength(50)]
    public string UpdatedBy { get; set; } = "System";
    
    [NotMapped]
    public IReadOnlyCollection<EventBase> DomainEvents => _domainEvents.AsReadOnly();
    
    private readonly List<EventBase> _domainEvents = new();
    
    public void AddDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public void RemoveDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}