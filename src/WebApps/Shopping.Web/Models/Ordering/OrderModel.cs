namespace Shopping.Web.Models.Ordering;

public record OrderModel(
    Guid Id,
    Guid CustometId,
    string OrderName,
    AddresModel ShippingAddress,
    AddresModel BillingAddress,
    PaymentModel Payment,
    OrderStatus Status,
    List<OrderItemModel> OrderItems
    );

public record AddresModel(
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string State,
    string ZipCode);
public record OrderItemModel(Guid OrderId, Guid PriductId, int Quantity, decimal Price);
public record PaymentModel(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);
public enum OrderStatus
{
    Draft = 0,
    Pending = 1,
    Completed = 2,
    Canceled = 3
}

//Wrappers
public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);
public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);
public record GetOrdersByCustomerResponse(IEnumerable<OrderModel> Orders);