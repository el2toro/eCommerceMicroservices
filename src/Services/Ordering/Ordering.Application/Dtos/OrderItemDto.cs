namespace Ordering.Application.Dtos;

public record OrderItemDto(Guid OrderId, Guid PriductId, int Quantity, decimal Price);

