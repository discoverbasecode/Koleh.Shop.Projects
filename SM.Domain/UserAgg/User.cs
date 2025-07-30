using Framework.Domain.Common;
using Framework.Domain.Exceptions;
using SM.Domain.UserAgg.Enums;

namespace SM.Domain.UserAgg;

public class User : AggregateRoot
{
    #region User Properties and Constructor and static Methods

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<Wallet> Wallets { get; private set; }

    public User()
    {
    }

    private User(
        string name, string family,
        string phone, string email,
        string password, Gender gender)
    {
        Name = name;
        Family = family;
        Phone = phone;
        Email = email;
        Password = password;
        Gender = gender;
    }

    public static User Create(
        string name, string family,
        string phone, string email,
        string password, Gender gender)
    {
        return new User(name, family, phone, email, password, gender);
    }

    public void Edit(
        string name, string family,
        string phone, string email, Gender gender)
    {
        Name = name;
        Family = family;
        Phone = phone;
        Email = email;
        Gender = gender;
    }

    #endregion
   
    #region User Address CRUD Methods

    public void AddAddress(UserAddress address)
    {
        address.Id = Id;
        Addresses.Add(address);
    }

    public void RemoveAddress(Guid addressId)
    {
        var firstAddress = Addresses.FirstOrDefault(c => c.Id == addressId);
        if (firstAddress == null)
            throw NotFoundException.Create("آدرس", addressId);
        Addresses.Remove(firstAddress);
    }

    public void EditAddress(UserAddress address)
    {
        var firstAddress = Addresses.FirstOrDefault(c => c.Id == address.Id);
        if (firstAddress == null)
            throw NotFoundException.Create("آدرس", address.Id);
        Addresses.Remove(firstAddress);
        Addresses.Add(address);
    }

    #endregion



}