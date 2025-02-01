namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler
    (IApplicationDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(command.Order);

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id.Value);
    }

    private Domain.Models.Order CreateNewOrder(OrderDto orderDto)
    {
        var shippingAddress = Address.Of(
            orderDto.SippingAddress.FirstName,
            orderDto.SippingAddress.LastName,
            orderDto.SippingAddress.EmailAddress,
            orderDto.SippingAddress.AddressLine,
            orderDto.SippingAddress.Country,
            orderDto.SippingAddress.State,
            orderDto.SippingAddress.ZipCode);

        var billingAddress = Address.Of(
            orderDto.BillingAddress.FirstName,
            orderDto.BillingAddress.LastName,
            orderDto.BillingAddress.EmailAddress,
            orderDto.BillingAddress.AddressLine,
            orderDto.BillingAddress.Country,
            orderDto.BillingAddress.State,
            orderDto.BillingAddress.ZipCode);

        var newOrder = Domain.Models.Order.Create(
            orderId: OrderId.Of(Guid.NewGuid()),
            customerId: CustomerId.Of(orderDto.CustometId),
            orderName: OrderName.Of(orderDto.OrderName),
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            payment: Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod)
            );

        foreach (var orderItemDto in orderDto.OrderItems)
        {
            newOrder.Add(ProductId.Of(orderItemDto.PriductId), orderItemDto.Quantity, orderItemDto.Price);
        }

        return newOrder;
    }
}
