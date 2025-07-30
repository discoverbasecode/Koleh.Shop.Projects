namespace Framework.Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }

    public string? CreatedIp { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public string? CreatedLocation { get; set; }

    public string? UpdatedIp { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? UpdatedLocation { get; set; }

    public string? DeletedIp { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public bool IsActive { get; set; } = true;

    public string? BlockedIp { get; set; }
    public bool IsBlocked { get; set; } = false;
    public DateTime? BlockedAt { get; set; }
    public string? BlockedBy { get; set; }

    public bool IsApproved { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
}