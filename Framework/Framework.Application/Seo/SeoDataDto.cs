using Framework.Domain.Common.ValueObjects;

namespace Framework.Application.Seo;

public class SeoDataDto
{
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeyWords { get; set; } = string.Empty;
    public string Canonical { get; set; } = string.Empty;

    public SeoData ToDomain()
    {
        return new SeoData(MetaKeyWords, MetaDescription, MetaTitle, Canonical);
    }
}