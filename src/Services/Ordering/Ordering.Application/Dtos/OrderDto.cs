using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record OrderDto(
    Guid Id,
    Guid CustometId,
    string OrderName,
    AddresDto ShippingAddress,
    AddresDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems);

