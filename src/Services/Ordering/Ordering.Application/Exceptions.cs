using BuildingBlocks.Exceptions;

namespace Ordering.Application
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("Order", id)
        {
        }
    }
}
