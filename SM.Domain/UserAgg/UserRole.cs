using Framework.Domain.Entities;

namespace SM.Domain.UserAgg;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public UserRole(Guid roleId)
    {
        RoleId = roleId;
    }
}