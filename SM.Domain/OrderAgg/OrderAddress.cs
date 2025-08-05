using Framework.Domain.Entities;

namespace SM.Domain.OrderAgg;

public class OrderAddress : BaseEntity
{
    public OrderAddress() { }
    private OrderAddress(string province, string city, string postalCode, string fullAddress, string receiverName, string phoneNumber)
    {
        Province = province;
        City = city;
        PostalCode = postalCode;
        FullAddress = fullAddress;
        ReceiverName = receiverName;
        PhoneNumber = phoneNumber;
    }

    public Guid OrderId { get; private set; }

    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string FullAddress { get; private set; }
    public string ReceiverName { get; private set; }
    public string PhoneNumber { get; private set; }
    public Order Order { get; set; }
}