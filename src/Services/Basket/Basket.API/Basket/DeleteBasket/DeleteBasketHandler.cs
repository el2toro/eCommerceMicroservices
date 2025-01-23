namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IQuery<DeletBasketResult>;
public record DeletBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

internal class DeleteBasketCommandHandler(IBasketRepository repository)
    : IQueryHandler<DeleteBasketCommand, DeletBasketResult>
{
    public async Task<DeletBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return new DeletBasketResult(true);
    }
}
