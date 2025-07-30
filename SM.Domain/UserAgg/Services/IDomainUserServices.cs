namespace SM.Domain.UserAgg.Services;

public interface IDomainUserServices
{
    bool IsEmailExist(string email);
    bool IsPhoneExist(string phone);
}