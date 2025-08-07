
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;

namespace SM.Domain.SliderAgg;

public class Slider : BaseEntity
{
    public string Title { get; private set; }
    public string Linke { get; private set; }
    public string ImageName { get; private set; }

    public Slider(string title, string link, string imageName)
    {
        Guard(title, link, imageName);
        Title = title;
        Linke = link;
        ImageName = imageName;
    }

    public void Edit(string title, string link, string imageName)
    {
        Guard(title, link, imageName);
        Title = title;
        Linke = link;
        ImageName = imageName;
        UpdatedAt = DateTime.Now;
    }

    private void Guard(string title, string link, string imageName)
    {
        if (title == null)
            throw InvalidFieldException.Create("عنوان", DomainMessageTemplate.NotEmpty);

        if (link == null)
            throw InvalidFieldException.Create("لینک", DomainMessageTemplate.NotEmpty);

        if (imageName == null)
            throw InvalidFieldException.Create("نام تصویر", DomainMessageTemplate.NotEmpty);
    }
}
