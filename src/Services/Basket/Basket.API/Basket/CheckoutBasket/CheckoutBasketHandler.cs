using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(CheckoutBasketDto CheckoutBasketDto) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.CheckoutBasketDto).NotNull().WithMessage("CheckoutBasketDto cannot be null");
        RuleFor(x => x.CheckoutBasketDto.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class CheckoutBasketHandler
    (IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        //get existing basket with total price
        //set total price on basketcheckout event message
        //send basketckechout event to rabbitmq using masstransit
        //delete the basket
        var basket = await repository.GetBasket(command.CheckoutBasketDto.UserName, cancellationToken);
        if (basket is null)
        {
            return new CheckoutBasketResult(false);
        }

        var eventMessage = command.CheckoutBasketDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.CheckoutBasketDto.UserName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}
