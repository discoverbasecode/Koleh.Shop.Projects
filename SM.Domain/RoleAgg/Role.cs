using Framework.Domain.Entities;
using Framework.Domain.Exceptions;

namespace SM.Domain.RoleAgg;

public class Role : BaseEntity
{
    #region Role Properties and Constructor and static Methods

    private Role()
    {
    }

    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }

    public Role(string title)
    {
        TitleGuard(title);
        Title = title;
        Permissions = new List<RolePermission>();
    }

    public Role(string title, List<RolePermission> permissions)
    {
        TitleGuard(title);
        Title = title;
        Permissions = permissions;
    }

    public void SetPermission(List<RolePermission> permissions)
    {
        Permissions = permissions;
    }

    public void Edit(string title)
    {
        TitleGuard(title);
        Title = title;
        UpdatedAt = DateTime.Now;
    }

    #endregion


    #region Guard Methods

    public void TitleGuard(string title)
    {
        if (Title == null)
            throw InvalidFieldException.Create("عنوان", "خالی است");
    }

    #endregion
}