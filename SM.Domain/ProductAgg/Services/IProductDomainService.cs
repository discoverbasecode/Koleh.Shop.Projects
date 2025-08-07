namespace SM.Domain.ProductAgg.Services;

public interface IProductDomainService
{
    bool SlugExists(string slug);
}