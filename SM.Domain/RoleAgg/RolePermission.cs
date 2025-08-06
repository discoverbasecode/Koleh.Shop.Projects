using SM.Domain.RoleAgg.Enums;

namespace SM.Domain.RoleAgg;

public class RolePermission
{
    #region Role Permission Properties and Constructor and static Methods

    public Guid RoleId { get; private set; }
    public Permission Permission { get; private set; }

    #endregion
}