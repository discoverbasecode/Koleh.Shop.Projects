using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using SM.Domain.BannerAgg.Enums;

namespace SM.Domain.BannerAgg;

public class Banner : BaseEntity
{
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition Position { get; private set; }

    public Banner(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Edit(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
        UpdatedAt = DateTime.Now;
    }

    private void Guard(string link, string imageName)
    {
        if (link == null)
            throw InvalidFieldException.Create("لینک", DomainMessageTemplate.NotEmpty);

        if (imageName == null)
            throw InvalidFieldException.Create("نام تصویر", DomainMessageTemplate.NotEmpty);
    }

}
