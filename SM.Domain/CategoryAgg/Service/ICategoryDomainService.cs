namespace SM.Domain.CategoryAgg.Service;

public interface ICategoryDomainService
{
    public bool SlugExists(string slug);
}